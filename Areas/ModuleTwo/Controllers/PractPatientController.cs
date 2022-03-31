using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
//using PainAssessment.Areas.ModuleTwo.Data;
//using PainAssessment.Areas.ModuleTwo.Models;
using PainAssessment.Areas.Admin.Services;
using System.Data;

namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class PractPatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IPractitionerService practitionerService;

        //public PatientController(IPatientService patientService)
        public PractPatientController(IPatientService patientService, IPractitionerService practitionerService)
        {
            this.patientService = patientService;
            this.practitionerService = practitionerService;
            //log = LogService.GetInstance;
        }

        // GET: Admin/Patients
        //public IActionResult Index()            // Will need to pass in Practitioner GUID here
        //{
        //    //Practitioner practitioner = practitionerService.GetPractitioner(Guid.Parse("bb4d34c0-a43b-4f6f-138b-08da09bb8f40"));
        //    //Patient patient = patientService.GetPatient(Guid.Parse("85f853ef-876e-48fb-173b-08da04e2f772"));
        //    //practitioner.AddPatientRelation(patient);
        //    //practitionerService.SavePractitioner();
        //    //return View(practitioner.Patients);
        //    return View(patientService.GetAllPatients());
        //}

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //   public async Task<IActionResult> Index(string sortOrder, string searchString){

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["CurrentFilter"] = searchString;

            //IEnumerable<Patient> patients = from s in patientService.GetAllPatients() select s;
            var patients = from s in patientService.GetAllPatients() select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                //patients = patients.Where(s => s.Name.Contains(searchString));
                patients = patients.Where(s => s.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "Name":
                    patients = patients.OrderByDescending(s => s.Name);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
            }
            //return View(await students.AsNoTracking().ToListAsync());

            int pageSize = 3;
            //return View(await PaginatedList<Patient>.CreateAsync(patients.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(patients.ToList());
        }

        // GET: Admin/Patients/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = patientService.GetPatient((Guid)id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Admin/Patients/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = patientService.GetPatient((Guid)id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Admin/Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    patientService.UpdatePatient(patient);
                    patientService.SavePatient();
                    //log.LogMessage("Info", GetType().Name, string.Format("{0} was modified.", patient.Name));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (patientService.GetPatient(patient.Id) == null)
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
            return View(patient);
        }

        // GET: Admin/Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)            // WILL PROBABLY NEED TO PASS IN PRACTITIONER INFO HERE ALSO
        {
            if (ModelState.IsValid)
            {
                patientService.CreatePatient(patient);
                patientService.SavePatient();
                Practitioner practitioner = practitionerService.GetPractitioner(Guid.Parse("bb4d34c0-a43b-4f6f-138b-08da09bb8f40"));
                practitioner.AddPatientRelation(patient);
                practitionerService.SavePractitioner();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Admin/Patients/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = patientService.GetPatient((Guid)id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Admin/Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            patientService.DeletePatient(id);
            patientService.SavePatient();
            //log.LogMessage("Info", GetType().Name, string.Format("{0} was deleted.", id));
            return RedirectToAction(nameof(Index));
        }
    }
}
