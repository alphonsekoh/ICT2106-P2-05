using Microsoft.AspNetCore.Http;
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
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        // Include services
        private readonly iProfileService profileService;
        // GET: ProfileController
        public ProfileController(ILogger<ProfileController> logger, iProfileService profileService)
        {
            _logger = logger;
            this.profileService = profileService;
        }
       
        public IActionResult ViewProfile()
        {
            //testing with the first record from db
            int id = 1; 
            var accountDetails = profileService.GetAccount(id);
            return View(accountDetails);
        }

        //Returns the current view from view profile page
        public IActionResult UpdateProfile(int id)
        {
            return ViewProfile();
        }

        [HttpPost]
        public ActionResult UpdateDetails(int accountID, string name, string username, string password, string role, int departmentId)
        {
            try
            {
                Account acc = profileService.GetAccount(accountID);

                profileService.UpdateAccount(acc.AccountId, acc.Name, acc.Username, acc.Password, acc.Role, acc.DepartmentId);
                return RedirectToAction(nameof(UpdateProfile));
            }
            catch
            {
                return View();
            }
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
        }

       
    }
}
