using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.ViewModels;
using System;

namespace PainAssessment.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService loginService;

        private const string REDIRECT_CNTR = "Home";
        private const string REDIRECT_ACTN = "Index";
        private const string DIRECT_CNTR = "Account";
        private const string DIRECT_ACTN = "Login";

        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _logger = logger;
            this.loginService = loginService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Test = false;
            return View(loginModel);
        }

        // POST: LoginController/Login
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var accountId = model.accountId;
            var password = model.Password;

            try
            {
                if(loginService.Login(accountId, password)  == true)
                {
                    return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
                }
                else
                {
                    LoginModel loginModel = new LoginModel();
                    loginModel.Test = true;
                    return View(loginModel);
                }
                
            }
            catch
            {
                return View();
            }
        }

    }
}
