using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // GET: Admin/Departments
        public IActionResult Index(string sortOrder, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            var department = from s in departmentService.GetAllDepartments() select s;
            switch (sortOrder)
            {
                case "Name":
                    department = department.OrderByDescending(s => s.Name);
                    break;
                default:
                    department = department.OrderBy(s => s.Name);
                    break;
            }

            ViewData["total_count"] = department.Count();

            int max_page = (int)Math.Ceiling((decimal)(department.Count() / 8.0));

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

            if (department.Count() > 0)
            {
                department = department.ChunkBy(8).ElementAt(page - 1);
            }

            return View(department.ToList());
        }

        // GET: Admin/Departments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentService.GetDepartment((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Admin/Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DepartmentID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentService.CreateDepartment(department);
                departmentService.SaveDepartment();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Admin/Departments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentService.GetDepartment((int)id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Admin/Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DepartmentID,Name")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    departmentService.UpdateDepartment(department);
                    departmentService.SaveDepartment();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (departmentService.GetDepartment(department.DepartmentID) == null)
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
            return View(department);
        }

        // GET: Admin/Departments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentService.GetDepartment((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Admin/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            departmentService.DeleteDepartment((int)id);
            departmentService.SaveDepartment();
            return RedirectToAction(nameof(Index));
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
}
