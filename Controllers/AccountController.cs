using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.ViewModels;

namespace PainAssessment.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService accountService;

        //private const string REDIRECT_CNTR = "Home";
        //private const string REDIRECT_ACTN = "Index";
        //private const string DIRECT_CNTR = "Account";
        //private const string DIRECT_ACTN = "Login";

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

    }
}
