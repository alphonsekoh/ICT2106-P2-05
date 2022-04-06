using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PainAssessment.Interfaces;
using Microsoft.Extensions.Logging;



namespace PainAssessment.Controllers
{
    public class TemplateChecklistController : Controller
    {

        //include services and logger
        private Areas.ModuleTwo.Services.IChecklistService checklistService;

        private readonly ILogger<TemplateChecklistController> _logger;
        
        private readonly ILoginService loginService;
        private readonly IDefaultQuestionsService defaultQuestionsService;
        private ITemplateChecklistAdapter TChecklistAdapter;


        public TemplateChecklistController(ILogger<TemplateChecklistController> logger, ITemplateChecklistService templateChecklistService, IDefaultQuestionsService defaultQuestionsService, ILoginService loginService, Areas.ModuleTwo.Services.IChecklistService checklistServ, ITemplateChecklistAdapter tchecklistadapter)
        {
            _logger = logger;
            this.loginService = loginService;
            checklistService = checklistServ;
            this.defaultQuestionsService = defaultQuestionsService;
            this.TChecklistAdapter = tchecklistadapter;
        }

        //get all template checklist by admin and display
        public IActionResult ViewTemplateChecklist()
        {
            var checklists = checklistService.GetAll(1);
            return View(checklists);
        }



        //navigate to create template checklist and initialise checklist object
        [HttpGet]
        public IActionResult CreateTemplateChecklist(int user)
        {
            var checklists = checklistService.InitialiseChecklist();
            return View(checklists);
        }
        //create template checklist
        [HttpPost]
        public IActionResult CreateTemplateChecklist(Areas.ModuleTwo.Models.Checklist checklist)
        {
            checklistService.Insert(checklist);
            return RedirectToAction(nameof(ViewTemplateChecklist));
        }

        // delete template checklist
        [HttpGet]
        public IActionResult DeleteTemplateChecklist(int id)
        {
            var checklist = checklistService.GetById(id);
            return View(checklist);
        }
        // confirm delete template checklist
        [HttpPost]
        public IActionResult DeleteTemplateChecklist(Areas.ModuleTwo.Models.Checklist checklist)
        {
            checklistService.Delete(checklist);
            return RedirectToAction(nameof(ViewTemplateChecklist));
        }
        // navigate to edit/update template checklist with the checklist id
        [HttpGet]
        public IActionResult EditTemplateChecklist(int id)
        {
            var checklist = checklistService.GetById(id);
            return View(checklist);
        }
        // edit/update template checklist with the checklist
        [HttpPost]
        public IActionResult EditTemplateChecklist(Areas.ModuleTwo.Models.Checklist checklist)
        {
            checklistService.Update(checklist);
            return RedirectToAction(nameof(ViewTemplateChecklist));
        }

        [HttpPost]
        public ActionResult Update(int checklistID)
        {
            TChecklistAdapter.updateActive(checklistID);
            return RedirectToAction(nameof(ViewTemplateChecklist));
        }

        /*
        //hui yang's manage checklist
        [HttpGet]
        public IActionResult ManageTemplateChecklist(int num)
        {
            var templateQuestionsArr = defaultQuestionsService.GetAllDefaultQuestionsFromTemplateChecklist(num).ToList();
            return View(templateQuestionsArr);
        }*/
        [HttpGet]
        public IActionResult ManageTemplateChecklist()
        {

            var checklist = this.checklistService.GetById(13);
            return View(checklist);
        }


        public IActionResult ManageTemplateChecklist(int checklistID)
        {

            var checklist = this.checklistService.GetById(checklistID);
            return View(checklist);
        }


        [HttpPost]
        public IActionResult AddQuestion(int checklistID, int domain, string new_determinant, string new_sub_domain, int new_max_weightage)
        {

            //defaultQuestionsService.CreateDefaultQuestion(1, QString, "", int.Parse(PainSection), double.Parse(weightage));
            this.TChecklistAdapter.addQuestion(checklistID, new_sub_domain, new_determinant, domain, new_max_weightage);
            Console.WriteLine("Inside addQuestion");
            //RedirectToAction()
            var newChecklistID = this.TChecklistAdapter.getRecentlyModifiedChecklist();
            return RedirectToAction("ManageTemplateChecklist", newChecklistID);
        }

    }
}
