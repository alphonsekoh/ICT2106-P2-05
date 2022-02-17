﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics; // TO REMOVE

namespace PainAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Include services
        private readonly ITemplateChecklistService templateChecklistService;
        private readonly IDefaultQuestionsService defaultQuestionsService;

        public HomeController(ILogger<HomeController> logger, ITemplateChecklistService templateChecklistService, IDefaultQuestionsService defaultQuestionsService)
        {
            _logger = logger;
            this.templateChecklistService = templateChecklistService;
            this.defaultQuestionsService = defaultQuestionsService;
        }

        public IActionResult Index()
        {
            var templateChecklistArr = templateChecklistService.GetAllTemplateChecklist().ToList();
            return View(templateChecklistArr);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ManageTemplateChecklist()
        {
            var templateQuestionsArr = defaultQuestionsService.GetAllDefaultQuestionsFromTemplateChecklist(1).ToList();
            return View(templateQuestionsArr);
        }

        [HttpPost]
        public string UpdateQuestion(int DQID, string QString, string weightage)
        {
            Debug.Write(weightage);
            DefaultQuestion temp = defaultQuestionsService.GetDefaultQuestion(DQID);

            defaultQuestionsService.UpdateDefaultQuestion(DQID, QString, temp.QDescription, temp.PainSection, double.Parse(weightage));



            return "Privacy";
        }

        [HttpPost]
        public string AddQuestion(int DQID, string QString, string PainSection, string weightage)
        {

            defaultQuestionsService.CreateDefaultQuestion(1, QString, "", int.Parse(PainSection), double.Parse(weightage));

            return "nth wrong";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
