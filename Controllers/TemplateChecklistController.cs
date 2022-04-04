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
        private Areas.ModuleTwo.Services.IChecklistService checklistService;


        private readonly ILogger<TemplateChecklistController> _logger;
        // Include services
        private readonly ILoginService loginService;
        //private readonly IDefaultQuestionsService defaultQuestionsService;

        public TemplateChecklistController(ILogger<TemplateChecklistController> logger, ITemplateChecklistService templateChecklistService, IDefaultQuestionsService defaultQuestionsService, ILoginService loginService, Areas.ModuleTwo.Services.IChecklistService checklistServ)
        {
            _logger = logger;
            this.loginService = loginService;
            checklistService = checklistServ;

            //this.defaultQuestionsService = defaultQuestionsService;
        }

        public IActionResult ViewTemplateChecklist()
        {
            var checklists = checklistService.GetAll(1);
            return View(checklists);
        }

        [HttpGet]
        public IActionResult CreateTemplateChecklist(int user)
        {
            var checklists = checklistService.InitialiseChecklist();
            return View(checklists);
        }

        [HttpPost]
        public IActionResult CreateTemplateChecklist(Areas.ModuleTwo.Models.Checklist checklist)
        {
            checklistService.Insert(checklist);
            return View("TemplateChecklistController");
        }

    }
}
