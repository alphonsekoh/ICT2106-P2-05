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
using PainAssessment.Areas.Admin.Models;

namespace PainAssessment.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        // Include services
        private readonly IAccountService accountService;
        private readonly IPractitionerService practitionerService;
        private readonly IAdministratorService administratorService;
        private readonly IClinicalAreaService clinicalAreaService;

        public ProfileController(ILogger<ProfileController> logger, IAccountService accountService, IPractitionerService practitionerService, IAdministratorService administratorService, IClinicalAreaService clinicalAreaService)
        {
            _logger = logger;
            this.accountService = accountService;
            this.practitionerService = practitionerService;
            this.administratorService = administratorService;
            this.clinicalAreaService = clinicalAreaService;
            
        }

        public ActionResult ViewProfile()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            string role = "Admin";
            string adminUsername = "admin1";
            Account userAcc = accountService.GetAccount(adminUsername);
            if (role =="Admin")
            {
                Administrator admin = administratorService.GetOneAdmin(userAcc.AccountId);
                var adminViewModel = new AdministratorModel
                {
                    Name = admin.Account.Username,
                    FullName = admin.FullName,
                    Role = admin.Account.Role,
                    Experience = admin.Experience,
                    AccountID = admin.Account.AccountId

                };
                //return RedirectToAction("ViewAdmin", adminViewModel);
                return View("ViewAdmin",adminViewModel);
            }
            else
            {
                Practitioner practionerDetails = practitionerService.GetPractitioner(userAcc.AccountId);
                ClinicalArea clinical = clinicalAreaService.GetClinicalArea(practionerDetails.ClinicalAreaID);
                var practionerViewModel = new PractionerModel
                {
                    Name = practionerDetails.Name,
                    FullName = userAcc.Username,
                    Role = userAcc.Role,
                    AccountID = userAcc.AccountId,
                    PriorPainEducation = practionerDetails.PriorPainEducation,
                    ClinicalArea = clinical.Name,
                    PracticeType = practionerDetails.PracticeType.Name

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
