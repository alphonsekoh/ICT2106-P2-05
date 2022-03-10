using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainAssessment.Interfaces;
using PainAssessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginController
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //if (loginService.Login(accountId, password) == true)
                //{
                //    return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
                //}
                //else
                //{
                //    ViewData["test"] = false;
                //    return View();
                //}

                if(await AuthenticateUser(model) == true)
                {
                    return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
                }
                else
                {
                    return View(model);
                }
            }
        }

        private async Task<bool> AuthenticateUser(LoginModel model)
        {
            string username = model.Username;
            string password = model.Password;

            if (loginService.Login(username, password) != null)
            {

                /* TODO 
                 * 1. Setup 1 ViewModel (storing data retreived database)
                 * 2. loginService.Login will verify entered credentials
                 * 3. Need to determine a way to retrieve credential details if found
                 * 4. Create new list of claims (claims) where each represent a peice of detail
                 * 5. Create new instance of ClaimsIdentity (with claims) and assign principal with the ClaimsIdentity
                 * 6. call await HttpContext.SignInAsyunc to register persistent authentication
                 * 7. return true and redirect to the page after successful login
                 * 
                 */

                var user = loginService.Login(username, password);

                // Attributes that are for authentication
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Account.Username)),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Email", user.Email)
                };

                // Initialise instance of ClaimsIdentity
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // Initialise new instance of ClaimsPrincipal
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                    //IsPersistent = true 
                });

                return true;
            }
            return false;
        }

        // Log out function
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to login page
            return LocalRedirect("/");
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
                loginService.UpdatePassword(model.Username, model.NewPassword, model.ConfirmPassword);
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
