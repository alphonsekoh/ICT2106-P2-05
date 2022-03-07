using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PractitionersController : Controller
    {
        private readonly IPractitionerService practitionerService;
        private readonly IClinicalAreaService clinicalAreaService;

        public PractitionersController(IPractitionerService practitionerService, IClinicalAreaService clinicalAreaService)
        {
            this.practitionerService = practitionerService;
            this.clinicalAreaService = clinicalAreaService;
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

            return View(practitioners);
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "ClinicalAreaID", "Name");

            return View();
        }

        // POST: Practitioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PractitionerID,Name,ClinicalAreaID")] Practitioner practitioner)
        {
            if (ModelState.IsValid)
            {
                practitionerService.CreatePractitioner(practitioner);
                practitionerService.SavePractitioner();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "ClinicalAreaID", "Name");

            return View(practitioner);
        }

        // GET: Practitioners/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practitioner = practitionerService.GetPractitioner((Guid)id);

            if (practitioner == null)
            {
                return NotFound();
            }

            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "ClinicalAreaID", "Name");
            return View(practitioner);
        }

        // POST: Practitioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("PractitionerID,Name,ClinicalAreaID")] Practitioner practitioner)
        {
            if (id != practitioner.PractitionerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    practitionerService.UpdatePractitioner(practitioner);
                    practitionerService.SavePractitioner();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (practitionerService.GetPractitioner(practitioner.PractitionerID) == null)
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

            ViewData["ClinicalAreaID"] = new SelectList(clinicalAreaService.GetAllClinicalAreas(), "ClinicalAreaID", "Name");
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


public static class ListExtensions
{
    public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
    {
        return source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}

public static class IEnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
    {
        for (int i = 0; i < source.Count(); i += chunkSize)
            yield return source.Skip(i).Take(chunkSize);
    }
}