using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Data;
using PainAssessment.Models;

namespace PainAssessment.Controllers
{
    public class PractitionersController : Controller
    {
        //private readonly IUnitOfWork unitOfWork;

        //public PractitionersController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}


        // GET: Practitioners
        public IActionResult Index()
        {
            var practitioners = new List<Practitioner> {
                new Practitioner{Id = 1, Name = "Test", Department = new Department{Name ="A&C" }},
                new Practitioner{Id = 2, Name = "Test2", Department = new Department{Name ="Female" }},
                new Practitioner{Id = 3, Name = "Test3", Department = new Department{Name ="Clinic" }},
                new Practitioner{Id = 4, Name = "Test", Department = new Department{Name ="A&C" }},
                new Practitioner{Id = 5, Name = "Test2", Department = new Department{Name ="Female" }},
                new Practitioner{Id = 6, Name = "Test3", Department = new Department{Name ="Clinic" }},
                new Practitioner{Id = 7, Name = "Test", Department = new Department{Name ="A&C" }},
                new Practitioner{Id = 8, Name = "Test2", Department = new Department{Name ="Female" }},
                new Practitioner{Id = 9, Name = "Test3", Department = new Department{Name ="Clinic" }}
            };

            return View(practitioners);
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(new List<Department> {
                new Department { Name = "A&C" },
                new Department { Name = "Female" },
                new Department { Name = "Clinic" } }, "Id", "Name");
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