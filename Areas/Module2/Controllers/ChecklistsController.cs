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

                .Where(a => a.Id == id).FirstOrDefault();
            return View(checklist);

        }

        // GET: ModuleTwo/Checklists/Create
        [HttpGet]
        public IActionResult Create()
        {
            Checklist checklist = new Checklist();
            checklist.Central.Add(new CentralDomain(){ RowId = 1 });
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
        public IActionResult Create(Checklist checklist)
        {

            _context.Add(checklist);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,checklistID,checklistName,checklistDescription")] Checklist checklist)
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
                .FirstOrDefaultAsync(m => m.Id == id);
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

        private bool ChecklistExists(int id)
        {
            return _context.Checklist.Any(e => e.Id == id);
        }
    }
}
