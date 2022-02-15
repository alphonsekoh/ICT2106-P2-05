using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PractitionersController : Controller
    {
        private readonly IPractitionerService practitionerService;


        public PractitionersController(IPractitionerService practitionerService)
        {
            this.practitionerService = practitionerService;
        }

        // GET: Admin/Practitioners?page=1
        public IActionResult Index(int page = 1)
        {
            int total_count = practitionerService.GetPractitionersCount();
            int max_page = (int)Math.Ceiling((decimal)(total_count / 8.0));

            if (page > max_page)
            {
                page = max_page;
            }
            else if (page < 1)
            {
                page = 1;
            }

            ViewData["total_count"] = total_count;
            ViewData["max_page"] = max_page;
            ViewData["current_page"] = page;

            return View(practitionerService.GetAllPractitionersByPage(page));
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(new List<Department> {
                new Department { Name = "A&C" },
                new Department { Name = "Female" },
                new Department { Name = "Clinic" } }, "DepartmentID", "Name");
            return View();
        }

        // POST: Practitioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DepartmentId,Id,Name")] Practitioner practitioner)
        {
            //if (ModelState.IsValid)
            //{
            //unitOfWork.Practitioners.CreatePractitioner(practitioner);
            //unitOfWork.Save();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["DepartmentId"] = new SelectList(unitOfWork.Departments.GetAllDepartments(), "Id", "Name");
            return View(practitioner);
        }

        // GET: Practitioners/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var practitioner = unitOfWork.Practitioners.GetPractitionerWithDetails((int)id);
            var practitioner = new Practitioner { Name = "Test", Department = new Department { Name = "A&C" } };
            if (practitioner == null)
            {
                return NotFound();
            }
            //ViewData["DepartmentId"] = new SelectList(unitOfWork.Departments.GetAllDepartments(), "Id", "Name");


            ViewData["DepartmentId"] = new SelectList(new List<Department> {
                new Department { Name = "A&C" },
                new Department { Name = "Female" },
                new Department { Name = "Clinic" } }, "Id", "Name");

            return View(practitioner);
        }

        //     // POST: Practitioners/Edit/5
        //     // To protect from overposting attacks, enable the specific properties you want to bind to.
        //     // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //     [HttpPost]
        //     [ValidateAntiForgeryToken]
        //     public IActionResult Edit(int id, [Bind("DepartmentId,Id,Name")] Practitioner practitioner)
        //     {
        //         if (id != practitioner.Id)
        //         {
        //             return NotFound();
        //         }

        //         if (ModelState.IsValid)
        //         {
        //             try
        //             {
        //                 unitOfWork.Practitioners.UpdatePractitioner(practitioner);
        //                 unitOfWork.Save();
        //             }
        //             catch (DbUpdateConcurrencyException)
        //             {
        //                 if (unitOfWork.Practitioners.GetById(practitioner.Id) == null)
        //                 {
        //                     return NotFound();
        //                 }
        //                 else
        //                 {
        //                     throw;
        //                 }
        //             }
        //             return RedirectToAction(nameof(Index));
        //         }
        //         ViewData["DepartmentId"] = new SelectList(unitOfWork.Departments.GetAllDepartments(), "Id", "Name");
        //         return View(practitioner);
        //     }

        //     // GET: Practitioners/Delete/5
        //     public IActionResult Delete(int? id)
        //     {
        //         if (id == null)
        //         {
        //             return NotFound();
        //         }

        //         var practitioner = unitOfWork.Practitioners.GetPractitionerWithDetails((int)id);

        //         if (practitioner == null)
        //         {
        //             return NotFound();
        //         }

        //         return View(practitioner);
        //     }

        //     // POST: Practitioners/Delete/5
        //     [HttpPost, ActionName("Delete")]
        //     [ValidateAntiForgeryToken]
        //     public IActionResult DeleteConfirmed(int id)
        //     {
        //         var practitioner = unitOfWork.Practitioners.GetPractitionerById((int)id);
        //         unitOfWork.Practitioners.DeletePractitioner(practitioner);
        //         unitOfWork.Save();
        //         return RedirectToAction(nameof(Index));
        //     }
        // }

        public JsonResult deletePractitioner(int Id)
        {

            //using (var context = new PractitionerDetailsEntities())
            //{
            //    var practitioner = context.Practitioner.Where(a => a.Id == Id).FirstOrDefault();
            //    practitioner.IsDeleted = true;
            //    context.SaveChanges();
            //}
            return Json(new { status = "Success" });

        }
    }
}