using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.Models;
using PainAssessment.ViewModels;
using System;
using BC = BCrypt.Net.BCrypt;

namespace PainAssessment.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService accountService;
        private readonly IAdministratorService administratorService;

        //private const string REDIRECT_CNTR = "Home";
        //private const string REDIRECT_ACTN = "Index";
        private const string DIRECT_CNTR = "Login";
        private const string DIRECT_ACTN = "Index";

        public AccountController(
            IAccountService accountService,
            IAdministratorService administratorService
           )
        {
            this.accountService = accountService;
            this.administratorService = administratorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                accountService.UpdatePassword(model.Username, model.NewPassword, model.ConfirmPassword);
                //ViewData["Message"] = "Password successfully changed!";
                //ViewData["MsgType"] = "success";
                return View(model);
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CreateAccount()
        {
            return View(new CreateAccountModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateAccount(CreateAccountModel model)
        {
            if (ModelState.IsValid)
            {
                if (accountService.CheckUsername(model.Username).Equals(false))
                {
                    var AccountId = Guid.NewGuid();
                    var cost = 16;

                    Account account = new Account
                    {
                        AccountId = AccountId,
                        Username = model.Username,
                        Password = BC.HashPassword(model.Password, cost),
                        Role = model.Role,
                        CreatedAt = DateTime.Now,
                        AccountStatus = "active",
                        FirstSignIn = true,
                        IsAuthenticated = false,
                    };

                    if (account != null)
                    {
                        accountService.CreateAcc(account);
                        if (account.Role == "Administrator")
                        {
                            // Administrator service
                            Administrator admin = new Administrator
                            {
                                Account = account,
                                FullName = model.FullName,
                                Experience = 0
                            };
                            administratorService.CreateAdmin(admin);
                        }
                        else
                        {
                            // Practitioner service
                        }
                        return RedirectToAction(DIRECT_ACTN, DIRECT_CNTR);
                    }
                    return View(model);
                }
                else
                {
                    ViewData["Message"] = "Username is taken. Please re-enter a username";
                    ViewData["MsgType"] = "danger";
                    return View(model);
                }

            }
            return View(model);
        }

    }
}
