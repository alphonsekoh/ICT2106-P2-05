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

       // private readonly ILogger<TemplateChecklistController> _logger;
        // Include services
        //private readonly ITemplateChecklistService templateChecklistService;
        //private readonly IDefaultQuestionsService defaultQuestionsService;

        /*public TemplateChecklistController(ILogger<TemplateChecklistController> logger, ITemplateChecklistService templateChecklistService, IDefaultQuestionsService defaultQuestionsService)
        {
            _logger = logger;
            this.templateChecklistService = templateChecklistService;
            this.defaultQuestionsService = defaultQuestionsService;
        }*/

        public TemplateChecklistController(Areas.ModuleTwo.Services.IChecklistService checklistServ)
        {
            checklistService = checklistServ;
        }
        public IActionResult ViewTemplateChecklist()
        {
            var checklists = checklistService.GetAll(0);
            return View(checklists);
        }
        /*public IActionResult ManageTemplateChecklist(int num)
        {
            var templateQuestionsArr = defaultQuestionsService.GetAllDefaultQuestionsFromTemplateChecklist(num).ToList();
            return View(templateQuestionsArr);
        }*/

        [HttpGet]
        public IActionResult Create(int user)
        {
            var checklists = checklistService.InitialiseChecklist();
             //same thing how to display the object
            return View(checklists);
        }

    }
}
