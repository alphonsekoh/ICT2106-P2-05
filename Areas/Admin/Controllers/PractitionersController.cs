using System.Collections.Generic;
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
        private readonly IDepartmentService departmentService;

        public PractitionersController(IPractitionerService practitionerService, IDepartmentService departmentService)
        {
            this.practitionerService = practitionerService;
            this.departmentService = departmentService;
        }

        // GET: Practitioners
        public IActionResult Index()
        {
            ViewData["DepartmentID"] = new SelectList(departmentService.GetAllDepartments(), "DepartmentID", "Name");
            return View(practitionerService.GetAllPractitioners());
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(departmentService.GetAllDepartments(), "DepartmentID", "Name");

            return View();
        }

        // POST: Practitioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DepartmentID,Id,Name")] Practitioner practitioner)
        {
            if (ModelState.IsValid)
            {
                practitionerService.CreatePractitioner(practitioner);
                practitionerService.SavePractitioner();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentID"] = new SelectList(departmentService.GetAllDepartments(), "DepartmentID", "Name");

            return View(practitioner);
        }

        // GET: Practitioners/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practitioner = practitionerService.GetPractitioner((int)id);

            if (practitioner == null)
            {
                return NotFound();
            }

            ViewData["DepartmentID"] = new SelectList(departmentService.GetAllDepartments(), "DepartmentID", "Name");
            return View(practitioner);
        }

        // POST: Practitioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DepartmentID,Id,Name")] Practitioner practitioner)
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

            ViewData["DepartmentID"] = new SelectList(departmentService.GetAllDepartments(), "DepartmentID", "Name");
            return View(practitioner);
        }

    public JsonResult deletePractitioner(int Id)
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