using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Areas.Admin.Services;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.ViewModels.Profile;
using System.Security.Claims;
using PainAssessment.Models;

namespace PainAssessment.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        // Include services
        private readonly IAccountService accountService;
        private readonly IPractitionerService practitionerService;
        private readonly IAdministratorService administratorService;

        public ProfileController(ILogger<ProfileController> logger, IAccountService accountService, IPractitionerService practitionerService, IAdministratorService administratorService)
        {
            _logger = logger;
            this.accountService = accountService;
            this.practitionerService = practitionerService;
            this.administratorService = administratorService;
            
        }

        public ActionResult ViewProfile()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            string role = "Admin";
            if(role =="Admin")
            {
                string username = "admin1";
                Administrator admin = administratorService.GetOneAdmin(username);
                var adminViewModel = new AdministratorModel
                {
                    Name = admin.Account.Username,
                    FullName = admin.FullName,
                    Role = admin.Account.Role,
                    Department = 1,
                    AccountID = admin.Account.AccountId

                };
                //return RedirectToAction("ViewAdmin", adminViewModel);
                return View("ViewAdmin",adminViewModel);
            }
            else
            {
                var practionerViewModel = new PractionerModel
                {
                    //var practionerDetails = practitionerService.GetPractitioner(id);
                };
                return View("ViewPractioner", practionerViewModel);
            }
            
        }


        private ActionResult ViewAdmin()
        {
            return View();
        }

        private ActionResult ViewPractioner()
        {
            return View();
        }


   /*     // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

      
    }
}
