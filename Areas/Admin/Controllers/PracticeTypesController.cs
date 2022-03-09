using Microsoft.AspNetCore.Mvc;
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
    public class PracticeTypesController : Controller
    {
        private readonly IPracticeTypeService practiceTypeService;
        private readonly ILog log;
        public PracticeTypesController(IPracticeTypeService practiceTypeService)
        {
            this.practiceTypeService = practiceTypeService;
            log = Log.GetInstance;
        }
        // GET: Admin/PracticeTypes
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            IEnumerable<PracticeType> practiceType = from d in practiceTypeService.GetAllPracticeTypes() select d;
            practiceType = sortOrder switch // check input of what is being sorted
            {
                "Name" => practiceType.OrderByDescending(d => d.Name),
                _ => practiceType.OrderBy(d => d.Name),
            };



            // check if not search input not empty
            if (!String.IsNullOrEmpty(searchString))
            {
                practiceType = practiceType.Where(d => d.Name.Contains(searchString));
            }

            ViewData["total_count"] = practiceType.Count(); // get count of all from

            int max_page = (int)Math.Ceiling((decimal)(practiceType.Count() / 8.0));

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

            if (practiceType.Any())
            {
                practiceType = practiceType.ChunkBy(8).ElementAt(page - 1);
            }

            return View(practiceType.ToList());
        }

        // GET: Admin/PracticeTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PracticeType practiceType = practiceTypeService.GetPracticeType((int)id);
            if (practiceType == null)
            {
                return NotFound();
            }

            return View(practiceType);
        }

        // GET: Admin/PracticeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PracticeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PracticeType practiceType)
        {
            if (ModelState.IsValid)
            {
                practiceTypeService.CreatePracticeType(practiceType);
                practiceTypeService.SavePracticeType();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was created.", practiceType.Name));
                return RedirectToAction(nameof(Index));
            }
            return View(practiceType);
        }

        // GET: Admin/PracticeTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PracticeType practiceType = practiceTypeService.GetPracticeType((int)id);

            if (practiceType == null)
            {
                return NotFound();
            }

            return View(practiceType);
        }

        // POST: Admin/PracticeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PracticeType practiceType)
        {
            if (id != practiceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    practiceTypeService.UpdatePracticeType(practiceType);
                    practiceTypeService.SavePracticeType();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (practiceTypeService.GetPracticeType(practiceType.Id) == null)
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
            log.LogMessage("Info", GetType().Name, string.Format("Renamed to {0}", practiceType.Name));
            return View(practiceType);
        }

        // GET: Admin/PracticeTypes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PracticeType practiceType = practiceTypeService.GetPracticeType((int)id);
            if (practiceType == null)
            {
                return NotFound();
            }

            return View(practiceType);
        }

        // POST: Admin/PracticeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                practiceTypeService.DeletePracticeType(id);
                practiceTypeService.SavePracticeType();
                log.LogMessage("Info", GetType().Name, string.Format("{0} deleted.", id));
            }
            catch (Exception e)
            {
                log.LogMessage("Info", GetType().Name, string.Format("{0} cannot be deleted. Practitioners still exist. {1}", id, e));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
