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
        //private readonly MvcChecklistContext _context;
        //private IUnitOfWork _unitOfWork;
        private IChecklistService checklistService;

        /*
        public ChecklistsController(IUnitOfWork unitOfWork)
        {
           // _context = context;
        }
        */
        public ChecklistsController(IChecklistService checklistServ)
        {
            // _context = context;
            checklistService = checklistServ;
        }

        public IActionResult Index()
        {
            /*
            List<Checklist> checklists;
            checklists = _context.Checklist.ToList();
            return View(checklists);
           
            var checklists = _unitOfWork.ChecklistRepo.GetAll();
            var checklist2 = _unitOfWork.ConsultationChecklistRepo.GetBySessionId(2);
            return View(checklists);
            */
            var checklists = checklistService.GetAll(2);
            var checklist2 = checklistService.GetBySessionId(4);
            return View(checklists);
        }
        // GET: ModuleTwo/Checklists/Details/5

        public IActionResult Details(int id)
        {
            /*
            Checklist checklist = _context.Checklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.ChecklistId == id).FirstOrDefault();
            return View(checklist);
            
            var checklist = _unitOfWork.ChecklistRepo.GetById(id);
            */
            var checklist = checklistService.GetById(id);
            return View(checklist);
        }

        // GET: ModuleTwo/Checklists/Create
        [HttpGet]
        public IActionResult Create(int user)
        {
            /*
            Checklist checklist = new Checklist();
            checklist.Central.Add(new CentralDomain() { RowId = 1 });
            checklist.Regional.Add(new RegionalDomain() { RowId = 1 });
            checklist.Local.Add(new LocalDomain() { RowId = 1 });
            return View(checklist);
            */
            var checklist = checklistService.InitialiseChecklist();
            return View(checklist);
        }

        // POST: ModuleTwo/Checklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public IActionResult Create(Checklist checklist)
        {
            /*
            checklist.Central.RemoveAll(n => n.IsCentralDeleted == true);
            checklist.Regional.RemoveAll(n => n.IsRegionalDeleted == true);
            checklist.Local.RemoveAll(n => n.IsLocalDeleted == true);
            _context.Add(checklist);
            _context.SaveChanges();
            return RedirectToAction("index");
            
            _unitOfWork.ChecklistRepo.InsertPost(checklist);
            
            var checklist2 = new Checklist();
            checklist2.SessionId = 2;
            checklist2.ChecklistName = "test consult2";
            checklist2.ChecklistDescription = "test2";
            _unitOfWork.ConsultationChecklistRepo.InsertConsultationChecklist(checklist2);

            _unitOfWork.Save();
            */
            checklistService.InsertPost(checklist);
            var checklist2 = checklistService.GetById(13);

            checklistService.InsertConsultationChecklist(checklist2);
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
            /*
            _unitOfWork.ChecklistRepo.PreUpdate(checklist);
            _unitOfWork.Save();

            _unitOfWork.ChecklistRepo.Update(checklist);
            _unitOfWork.Save();
            */
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
            //return _context.Checklist.Any(e => e.ChecklistId == id);
            //return _unitOfWork.ChecklistRepo.CheckExists(id);
            return checklistService.ChecklistExists(id);
        }
    }
}
