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
    public class PainEducationsController : Controller
    {
        private readonly IPainEducationService painEducationService;
        private readonly ILog log;
        public PainEducationsController(IPainEducationService painEducationService)
        {
            this.painEducationService = painEducationService;
            log = Log.GetInstance;
        }
        // GET: Admin/PainEducations
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            IEnumerable<PainEducation> painEducation = from d in painEducationService.GetAllPainEducations() select d;
            painEducation = sortOrder switch // check input of what is being sorted
            {
                "Name" => painEducation.OrderByDescending(d => d.Name),
                _ => painEducation.OrderBy(d => d.Name),
            };



            // check if not search input not empty
            if (!String.IsNullOrEmpty(searchString))
            {
                painEducation = painEducation.Where(d => d.Name.Contains(searchString));
            }

            ViewData["total_count"] = painEducation.Count(); // get count of all from

            int max_page = (int)Math.Ceiling((decimal)(painEducation.Count() / 8.0));

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

            if (painEducation.Any())
            {
                painEducation = painEducation.ChunkBy(8).ElementAt(page - 1);
            }

            return View(painEducation.ToList());
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
