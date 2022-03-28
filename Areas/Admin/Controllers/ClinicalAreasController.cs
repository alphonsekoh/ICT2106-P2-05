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
    public class ClinicalAreasController : Controller
    {
        private readonly IClinicalAreaService clinicalAreaService;
        private readonly ITableUltilityService<ClinicalArea> tableUltilityService;
        private readonly ILogService log;

        public ClinicalAreasController(IClinicalAreaService clinicalAreaService)
        {
            this.clinicalAreaService = clinicalAreaService;
            log = LogService.GetInstance;
            tableUltilityService = TableUltilityService<ClinicalArea>.GetInstance;
        }

        // GET: Admin/ClinicalAreas
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["searchString"] = searchString;
            searchString = String.IsNullOrEmpty(searchString) ? "" : searchString;

            IEnumerable<ClinicalArea> clinicalAreas = clinicalAreaService.GetAllClinicalAreas();

            clinicalAreas = tableUltilityService.Sort(clinicalAreas, "Name", String.IsNullOrEmpty(sortOrder) ? tableUltilityService.ORDER_BY : tableUltilityService.ORDER_BY_DESC);

            clinicalAreas = tableUltilityService.Search(clinicalAreas, searchString.ToLower());

            // Pagination.
            ViewData["max_page"] = tableUltilityService.GetMaxPageCount(clinicalAreas);
            ViewData["current_page"] = page = tableUltilityService.ValidateCurrentPage(page, clinicalAreas);
            clinicalAreas = tableUltilityService.GetPageData(clinicalAreas, page);

            ViewData["total_count"] = clinicalAreas.Count();

            return View(clinicalAreas.ToList());
        }

        // GET: Admin/ClinicalAreas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClinicalArea clinicalArea = clinicalAreaService.GetClinicalArea((int)id);
            if (clinicalArea == null)
            {
                return NotFound();
            }

            return View(clinicalArea);
        }

        // GET: Admin/ClinicalAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClinicalAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClinicalArea clinicalArea)
        {
            if (ModelState.IsValid)
            {
                clinicalAreaService.CreateClinicalArea(clinicalArea);
                clinicalAreaService.SaveClinicalArea();
                log.LogMessage("Info", GetType().Name, string.Format("{0} was created.", clinicalArea.Name));
                return RedirectToAction(nameof(Index));
            }
            return View(clinicalArea);
        }

        // GET: Admin/ClinicalAreas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClinicalArea clinicalArea = clinicalAreaService.GetClinicalArea((int)id);

            if (clinicalArea == null)
            {
                return NotFound();
            }

            return View(clinicalArea);
        }

        // POST: Admin/ClinicalAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClinicalArea clinicalArea)
        {
            if (id != clinicalArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clinicalAreaService.UpdateClinicalArea(clinicalArea);
                    clinicalAreaService.SaveClinicalArea();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (clinicalAreaService.GetClinicalArea(clinicalArea.Id) == null)
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
            log.LogMessage("Info", GetType().Name, string.Format("Renamed to {0}", clinicalArea.Name));
            return View(clinicalArea);
        }

        // GET: Admin/ClinicalAreas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClinicalArea clinicalArea = clinicalAreaService.GetClinicalArea((int)id);
            if (clinicalArea == null)
            {
                return NotFound();
            }

            return View(clinicalArea);
        }

        // POST: Admin/ClinicalAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                clinicalAreaService.DeleteClinicalArea(id);
                clinicalAreaService.SaveClinicalArea();
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
