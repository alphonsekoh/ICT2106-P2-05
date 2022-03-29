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
    public class PracticeTypesController : Controller
    {
        private readonly IPracticeTypeService practiceTypeService;
        private readonly ILogService log;
        private readonly ITableUtilityService<PracticeType> tableUtilityService;

        public PracticeTypesController(IPracticeTypeService practiceTypeService)
        {
            this.practiceTypeService = practiceTypeService;
            log = LogService.GetInstance;
            tableUtilityService = TableUtilityService<PracticeType>.GetInstance;
        }

        // GET: Admin/PracticeTypes
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["searchString"] = searchString;
            searchString = String.IsNullOrEmpty(searchString) ? "" : searchString;

            IEnumerable<PracticeType> practiceTypes = practiceTypeService.GetAllPracticeTypes();

            practiceTypes = tableUtilityService.Sort(practiceTypes, "Name", String.IsNullOrEmpty(sortOrder) ? tableUtilityService.ORDER_BY : tableUtilityService.ORDER_BY_DESC);

            practiceTypes = tableUtilityService.Search(practiceTypes, searchString.ToLower());

            // Pagination.
            ViewData["max_page"] = tableUtilityService.GetMaxPageCount(practiceTypes);
            ViewData["current_page"] = page = tableUtilityService.ValidateCurrentPage(page, practiceTypes);
            practiceTypes = tableUtilityService.GetPageData(practiceTypes, page);

            ViewData["total_count"] = practiceTypes.Count();

            return View(practiceTypes.ToList());
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
