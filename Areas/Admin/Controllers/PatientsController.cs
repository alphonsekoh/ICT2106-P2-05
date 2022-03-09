using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;
using System;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientsController : Controller
    {
        private readonly IPatientService patientService;
        private readonly ILog log;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
            log = Log.GetInstance;

        }

        // GET: Admin/Patients
        public IActionResult Index()
        {
            return View(patientService.GetAllPatients());
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
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientService.CreatePatient(patient);
                patientService.SavePatient();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was created.", patient.Name));
                return RedirectToAction(nameof(Index));
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
                    log.LogMessage("Info", GetType().Name, string.Format("{0} was modified.", patient.Name));

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
            log.LogMessage("Info", GetType().Name, string.Format("{0} was deleted.", id));
            return RedirectToAction(nameof(Index));
        }
    }
}
