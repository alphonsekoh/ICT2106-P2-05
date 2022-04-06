using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;
using PainAssessment.Areas.ModuleTwo.Services;

namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class ChecklistsController : Controller
    {
        private IChecklistService checklistService;

        public ChecklistsController(IChecklistService checklistServ)
        {

            checklistService = checklistServ;
        }

        public IActionResult Index()
        {

            var checklists = checklistService.GetAll(0);

            return View(checklists);
        }
        // GET: ModuleTwo/Checklists/Details/5

        public IActionResult Details(int id)
        {

            var checklist = checklistService.GetById(id);
            //var checklist = checklistService.GetBySessionId(2);
            return View(checklist);
        }

        // GET: ModuleTwo/Checklists/Create
        [HttpGet]
        public IActionResult Create(int user)
        {

            //var checklist = checklistService.InitialiseChecklist();
            return View(checklistService.InitialiseChecklist());
        }

        // POST: ModuleTwo/Checklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public IActionResult Create(Checklist checklist)
        {
            checklistService.Insert(checklist);

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var checklist = checklistService.GetById(id);
            return View(checklist);
            
        }

        [HttpPost]
        public IActionResult Edit(Checklist checklist)
        {

            checklistService.Update(checklist);
            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var checklist = checklistService.GetById(id);
            return View(checklist);
        }
        [HttpPost]
        public IActionResult Delete(Checklist checklist)
        {

            checklistService.Delete(checklist);
            return RedirectToAction("index");

        }
        private bool ChecklistExists(int id)
        {
            return checklistService.ChecklistExists(id);
        }
    }
}
