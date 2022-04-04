using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PainEducationsController : Controller
    {
        private readonly IPainEducationService painEducationService;
        private readonly ILogService log;
        private readonly ITableUtilityService<PainEducation> tableUtilityService;

        public PainEducationsController(IPainEducationService painEducationService)
        {
            this.painEducationService = painEducationService;
            log = LogService.GetInstance;
            tableUtilityService = TableUtilityService<PainEducation>.GetInstance;
        }

        // GET: Admin/PainEducations
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["searchString"] = searchString;
            searchString = String.IsNullOrEmpty(searchString) ? "" : searchString;

            IEnumerable<PainEducation> painEducations = painEducationService.GetAllPainEducations();

            painEducations = tableUtilityService.Sort(painEducations, "Name", String.IsNullOrEmpty(sortOrder) ? tableUtilityService.ORDER_BY : tableUtilityService.ORDER_BY_DESC);

            painEducations = tableUtilityService.Search(painEducations, searchString.ToLower());

            // Pagination.
            ViewData["max_page"] = tableUtilityService.GetMaxPageCount(painEducations);
            ViewData["current_page"] = page = tableUtilityService.ValidateCurrentPage(page, painEducations);
            painEducations = tableUtilityService.GetPageData(painEducations, page);

            ViewData["total_count"] = painEducations.Count();

            return View(painEducations.ToList());
        }

        // GET: Admin/PainEducations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PainEducation painEducation = painEducationService.GetPainEducation((int)id);
            if (painEducation == null)
            {
                return NotFound();
            }

            return View(painEducation);
        }

        // GET: Admin/PainEducations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PainEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PainEducation painEducation)
        {
            if (ModelState.IsValid)
            {
                painEducationService.CreatePainEducation(painEducation);
                painEducationService.SavePainEducation();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was created.", painEducation.Name));
                return RedirectToAction(nameof(Index));
            }
            return View(painEducation);
        }

        // GET: Admin/PainEducations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PainEducation painEducation = painEducationService.GetPainEducation((int)id);

            if (painEducation == null)
            {
                return NotFound();
            }

            return View(painEducation);
        }

        // POST: Admin/PainEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PainEducation painEducation)
        {
            if (id != painEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    painEducationService.UpdatePainEducation(painEducation);
                    painEducationService.SavePainEducation();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (painEducationService.GetPainEducation(painEducation.Id) == null)
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
            log.LogMessage("Info", GetType().Name, string.Format("Renamed to {0}", painEducation.Name));
            return View(painEducation);
        }

        // GET: Admin/PainEducations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PainEducation painEducation = painEducationService.GetPainEducation((int)id);
            if (painEducation == null)
            {
                return NotFound();
            }

            return View(painEducation);
        }

        // POST: Admin/PainEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                painEducationService.DeletePainEducation(id);
                painEducationService.SavePainEducation();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was deleted.", id));
            }
            catch (Exception e)
            {
                log.LogMessage("Info", GetType().Name, string.Format("{0} cannot be deleted. Practitioners still exist. {1}", id, e));

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
