using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class ChecklistsController : Controller
    {
        private readonly MvcChecklistContext _context;

        public ChecklistsController(MvcChecklistContext context)
        {
            _context = context;
        }

        // GET: ModuleTwo/Checklists
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checklist.ToListAsync());
        }
    */
        public IActionResult Index()
        {
            List<Checklist> checklists;
            checklists = _context.Checklist.ToList();
            return View(checklists);

        }
        // GET: ModuleTwo/Checklists/Details/5
        /*
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }
        */
        public IActionResult Details(int id)
        {
            Checklist checklist = _context.Checklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.ChecklistId == id).FirstOrDefault();
            return View(checklist);

        }

        // GET: ModuleTwo/Checklists/Create
        [HttpGet]
        public IActionResult Create()
        {
            Checklist checklist = new Checklist();
            checklist.Central.Add(new CentralDomain() { RowId = 1 });
            checklist.Regional.Add(new RegionalDomain() { RowId = 1 });
            checklist.Local.Add(new LocalDomain() { RowId = 1 });
            return View(checklist);
        }

        // POST: ModuleTwo/Checklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,checklistID,checklistName,checklistDescription")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checklist);
        }
        */
        [HttpPost]
        public IActionResult Create(Checklist checklist)
        {
            checklist.Central.RemoveAll(n => n.IsDeleted == true);
            checklist.Regional.RemoveAll(n => n.IsDeleted == true);
            checklist.Local.RemoveAll(n => n.IsDeleted == true);
            _context.Add(checklist);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Checklist checklist = _context.Checklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.ChecklistId == id).FirstOrDefault();
            return View(checklist);

        }

        [HttpPost]
        public IActionResult Edit(Checklist checklist)
        {
            List<CentralDomain> centralDetails = _context.CentralDomain.Where(d => d.ChecklistId == checklist.ChecklistId).ToList();
            List<RegionalDomain> regionalDetails = _context.RegionalDomain.Where(d => d.ChecklistId == checklist.ChecklistId).ToList();
            List<LocalDomain> localDetails = _context.LocalDomain.Where(d => d.ChecklistId == checklist.ChecklistId).ToList();
            _context.CentralDomain.RemoveRange(centralDetails);
            _context.RegionalDomain.RemoveRange(regionalDetails);
            _context.LocalDomain.RemoveRange(localDetails);
            //checklist.Central.RemoveRange(centralDetails);
            _context.SaveChanges();

            checklist.Central.RemoveAll(n => n.IsDeleted == true);
            checklist.Regional.RemoveAll(n => n.IsDeleted == true);
            checklist.Local.RemoveAll(n => n.IsDeleted == true);
            _context.Attach(checklist);
            _context.Entry(checklist).State = EntityState.Modified;
            _context.CentralDomain.AddRange(checklist.Central);
            _context.RegionalDomain.AddRange(checklist.Regional);
            _context.LocalDomain.AddRange(checklist.Local);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

        /*
        // GET: ModuleTwo/Checklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklist.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }
            return View(checklist);
        }

        // POST: ModuleTwo/Checklists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,checklistName,checklistDescription")] Checklist checklist)
        {
            if (id != checklist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecklistExists(checklist.Id))
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
            return View(checklist);
        }
        
        // GET: ModuleTwo/Checklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklist
                .FirstOrDefaultAsync(m => m.ChecklistId == id);
            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // POST: ModuleTwo/Checklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checklist = await _context.Checklist.FindAsync(id);
            _context.Checklist.Remove(checklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Checklist checklist = _context.Checklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.ChecklistId == id).FirstOrDefault();
            return View(checklist);

        }
        [HttpPost]
        public IActionResult Delete(Checklist checklist)
        {
            _context.Attach(checklist);
            _context.Entry(checklist).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        private bool ChecklistExists(int id)
        {
            return _context.Checklist.Any(e => e.ChecklistId == id);
        }
    }
}
