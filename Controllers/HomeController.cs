using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Include services
        private readonly ITemplateChecklistService templateChecklistService;

        public HomeController(ILogger<HomeController> logger, ITemplateChecklistService templateChecklistService)
        {
            _logger = logger;
            this.templateChecklistService = templateChecklistService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
