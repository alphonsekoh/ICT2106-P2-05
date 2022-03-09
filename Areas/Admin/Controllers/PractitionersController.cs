using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;
using PainAssessment.Areas.Admin.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PractitionersController : Controller
    {
        private readonly IPractitionerService practitionerService;
        private readonly IClinicalAreaService clinicalAreaService;
        private readonly IPracticeTypeService practiceTypeService;
        private readonly IPainEducationService painEducationService;
        private readonly IPatientService patientService;
        private readonly ILog log;
        public PractitionersController(IPractitionerService practitionerService, IClinicalAreaService clinicalAreaService, IPracticeTypeService practiceTypeService, IPatientService patientService, IPainEducationService painEducationService)
        {
            this.practitionerService = practitionerService;
            this.clinicalAreaService = clinicalAreaService;
            this.practiceTypeService = practiceTypeService;
            this.patientService = patientService;
            this.painEducationService = painEducationService;

            log = Log.GetInstance;
        }

        // GET: Admin/Practitioners?page=1&name=gerald
        public IActionResult Index(int page = 1, string name = "")
        {
            IEnumerable<Practitioner> practitioners = practitionerService.GetAllPractitioners();

            if (name != null)
            {
                practitioners = practitioners.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            ViewData["total_count"] = practitioners.Count();

            int max_page = (int)Math.Ceiling((decimal)(practitioners.Count() / 8.0));

            if (page > max_page)
            {
                page = max_page;
            }
            if (page < 1)
            {
                page = 1;
            }

            ViewData["max_page"] = max_page;
            ViewData["current_page"] = page;
            ViewData["name"] = name;

            if (practitioners.Any())
            {
                practitioners = practitioners.ChunkBy(8).ElementAt(page - 1);
            }

            Dictionary<Guid, List<string>> practitionerPain = new();
            // convert comma delimited string to list


            Dictionary<int, string> painEducationDict = painEducationService.GetAllPainEducations().ToList().ToDictionary(x => x.Id, x => x.Name);

            foreach (Practitioner practitioner in practitioners)
            {
                List<string> tempPainList = new();
                List<int> painEducationID = practitioner.PriorPainEducation.Split(',').Select(int.Parse).ToList();
                foreach (int id in painEducationID)
                {
                    bool exists = painEducationDict.TryGetValue(id, out string painName);
                    if (exists)
                    {
                        tempPainList.Add(painName);
                    }
                    else
                    {
                        tempPainList.Add(string.Format("${0} do not exist", id));
                    }
                }
                practitionerPain.Add(practitioner.Id, tempPainList);
            }
            ViewData["PractitionerPain"] = practitionerPain;
            return View(practitioners);
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "Id", "Name");
            ViewData["PracticeTypeID"] = new SelectList(practiceTypeService.GetAllPracticeTypes(), "Id", "Name");
            ViewData["PainEducationID"] = new MultiSelectList(painEducationService.GetAllPainEducations(), "Id", "Name");
            return View();
        }

        // POST: Practitioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Practitioner practitioner)
        {
            if (ModelState.IsValid)
            {
                practitionerService.CreatePractitioner(practitioner);
                practitionerService.SavePractitioner();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was created.", practitioner.Name));
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "Id", "Name");
            ViewData["PracticeTypeID"] = new SelectList(practiceTypeService.GetAllPracticeTypes(), "Id", "Name");
            ViewData["PainEducationID"] = new MultiSelectList(painEducationService.GetAllPainEducations(), "Id", "Name");
            return View(practitioner);
        }

        // GET: Practitioners/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Practitioner practitioner = practitionerService.GetPractitioner((Guid)id);

            if (practitioner == null)
            {
                return NotFound();
            }

            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "Id", "Name");
            ViewData["PracticeTypeID"] = new SelectList(practiceTypeService.GetAllPracticeTypes(), "Id", "Name");
            ViewData["PainEducationID"] = new MultiSelectList(painEducationService.GetAllPainEducations(), "Id", "Name");

            // multi select
            practitioner.SelectedPainEducation = practitioner.PriorPainEducation.Split(',').ToArray();

            return View(practitioner);
        }

        // POST: Practitioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Practitioner practitioner)
        {
            if (id != practitioner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    practitionerService.UpdatePractitioner(practitioner);
                    practitionerService.SavePractitioner();
                    log.LogMessage("Info", GetType().Name, string.Format("{0} was modified.", practitioner.Name));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (practitionerService.GetPractitioner(practitioner.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "Id", "Name");
            ViewData["PracticeTypeID"] = new SelectList(practiceTypeService.GetAllPracticeTypes(), "Id", "Name");
            ViewData["PainEducationID"] = new MultiSelectList(painEducationService.GetAllPainEducations(), "Id", "Name");
            return View(practitioner);
        }

        public JsonResult DeletePractitioner(Guid Id)
        {
            if (practitionerService.GetPractitioner(Id) == null)
            {
                return Json(new { status = "Fail" });
            }

            try
            {
                practitionerService.DeletePractitioner(Id);
                practitionerService.SavePractitioner();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was deleted.", Id));
                return Json(new { status = "Success" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (practitionerService.GetPractitioner(Id) == null)
                {
                    return Json(new { status = "Fail" });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}



