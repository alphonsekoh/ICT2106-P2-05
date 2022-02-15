using System;
using System.Collections.Generic;
using System.Linq;
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

            if (practitioners.Count() > 0)
            {
                practitioners = practitioners.ChunkBy(8).ElementAt(page - 1);
            }

            return View(practitioners);
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