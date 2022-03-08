using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Models.ModelBinder;
using PainAssessment.Areas.Admin.Services;
using PainAssessment.Areas.Admin.Util;

namespace PainAssessment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClinicalAreasController : Controller
    {
        private readonly IClinicalAreaService clinicalAreaService;
        private readonly ILog log;
        public ClinicalAreasController(IClinicalAreaService clinicalAreaService)
        {
            this.clinicalAreaService = clinicalAreaService;
            log = Log.GetInstance;
        }
        // GET: Admin/ClinicalAreas
        /*
         Index function to take in input from get upon search, sorting and page change
         */
        public IActionResult Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            var clinicalArea = from d in clinicalAreaService.GetAllClinicalAreas() select d;
            clinicalArea = sortOrder switch // check input of what is being sorted
            {
                "Name" => clinicalArea.OrderByDescending(d => d.Name),
                _ => clinicalArea.OrderBy(d => d.Name),
            };
            
            

            // check if not search input not empty
            if (!String.IsNullOrEmpty(searchString))
            {
                clinicalArea = clinicalArea.Where(d => d.Name.Contains(searchString));
            }

            ViewData["total_count"] = clinicalArea.Count(); // get count of all from

            int max_page = (int)Math.Ceiling((decimal)(clinicalArea.Count() / 8.0));

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

            if (clinicalArea.Any())
            {
                clinicalArea = clinicalArea.ChunkBy(8).ElementAt(page - 1);
            }

            return View(clinicalArea.ToList());
        }

        // GET: Admin/ClinicalAreas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalArea = clinicalAreaService.GetClinicalArea((int)id);
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
        public IActionResult Create([ModelBinder(typeof(ClinicalAreaModelBinder))] ClinicalArea clinicalArea)
        {
            if (ModelState.IsValid)
            {
                clinicalAreaService.CreateClinicalArea(clinicalArea);
                clinicalAreaService.SaveClinicalArea();
                log.LogMessage("Info", this.GetType().Name, string.Format("{0} was created.", clinicalArea.Name));
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

            var clinicalArea = clinicalAreaService.GetClinicalArea((int)id);

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
        public IActionResult Edit(int id, [ModelBinder(typeof(ClinicalAreaModelBinder))] ClinicalArea clinicalArea)
        {
            if (id != clinicalArea.ClinicalAreaID)
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
                    if (clinicalAreaService.GetClinicalArea(clinicalArea.ClinicalAreaID) == null)
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
            log.LogMessage("Info", this.GetType().Name, string.Format("Renamed to {0}", clinicalArea.Name));
            return View(clinicalArea);
        }

        // GET: Admin/ClinicalAreas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalArea = clinicalAreaService.GetClinicalArea((int)id);
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
            clinicalAreaService.DeleteClinicalArea((int)id);
            clinicalAreaService.SaveClinicalArea();
            log.LogMessage("Info", this.GetType().Name, string.Format("{0} was deleted.", id));
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
