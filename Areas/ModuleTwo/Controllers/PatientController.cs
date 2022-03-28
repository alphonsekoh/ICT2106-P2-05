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
using System.Collections.Generic;
using System.Linq;


namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IPractitionerService practitionerService;

        //public PatientController(IPatientService patientService)
        public PatientController(IPatientService patientService, IPractitionerService practitionerService)
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

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Patient> patients = from s in patientService.GetAllPatients() select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    patients = patients.OrderByDescending(s => s.Name);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
            }
            //return View(await students.AsNoTracking().ToListAsync());
            return View(patients.ToList());
        }

        //========================================================================================

        //public IActionResult Index(string sortOrder, string searchString, int page = 1)
        //{
        //    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
        //    IEnumerable<Patient> patient = from i in patientService.GetAllPatients() select i;
        //    patient = sortOrder switch // check input of what is being sorted
        //    {
        //        "Name" => patient.OrderByDescending(i => i.Name),
        //        _ => patient.OrderBy(i => i.Name),
        //    };

        //    // check if not search input not empty
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        patient = patient.Where(i => i.Name.ToLower().Contains(searchString.ToLower()));
        //    }

        //    ViewData["total_count"] = patient.Count(); // get count of all from

        //    int max_page = (int)Math.Ceiling((decimal)(patient.Count() / 8.0));

        //    if (page > max_page)
        //    {
        //        page = max_page;
        //    }
        //    if (page < 1)
        //    {
        //        page = 1;
        //    }

        //    ViewData["max_page"] = max_page;
        //    ViewData["current_page"] = page;

        //    if (patient.Any())
        //    {
        //        patient = patient.ChunkBy(8).ElementAt(page - 1);
        //    }

        //    return View(patient.ToList());
        //}

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

        //-----------------------------------------------------------------------

        //private readonly MvcPatientContext _context;

        //public PatientController(MvcPatientContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var patient = from m in _context.Patient
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        patient = patient.Where(s => s.patientName.Contains(searchString));
        //    }

        //    return View(await patient.ToListAsync());
        //}

        //// GET: ModuleTwo/Patient/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _context.Patient
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(patient);
        //}

        //// GET: ModuleTwo/Patient/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ModuleTwo/Patient/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,patientName,patientAge,condition,gender,consultationID,patientNotes,lastVisit")] Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(patient);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(patient);
        //}

        //// GET: ModuleTwo/Patient/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _context.Patient.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(patient);
        //}

        //// POST: ModuleTwo/Patient/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,patientName,patientAge,condition,gender,consultationID,patientNotes,lastVisit")] Patient patient)
        //{
        //    if (id != patient.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(patient);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PatientExists(patient.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(patient);
        //}

        //// GET: ModuleTwo/Patient/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _context.Patient
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(patient);
        //}

        //// POST: ModuleTwo/Patient/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var patient = await _context.Patient.FindAsync(id);
        //    _context.Patient.Remove(patient);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PatientExists(int id)
        //{
        //    return _context.Patient.Any(e => e.Id == id);
        //}
    }
}
