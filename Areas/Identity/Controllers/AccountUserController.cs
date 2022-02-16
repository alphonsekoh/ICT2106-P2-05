using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PainAssessment.Areas.Identity.Data;
using PainAssessment.Areas.Identity.Pages.Account;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Identity.Controllers
{
    public class AccountUserController : Controller
    {

        private const string ROLE_COL = "AccountRole";
        private const string NAME_COL = "FullName";
        private const string ACCID_COL = "AccountId";
        private const string Statussql = "AccountStatus";

        private const string REDIRECT_CNTR = "Home";
        private const string REDIRECT_ACTN = "Index";
        private const string DIRECT_CNTR = "AccountUser";
        private const string DIRECT_ACTN = "LoginPage";

        private UserManager<AccountUser> UserMgr { get; }
        private SignInManager<AccountUser> SignInMgr { get; }

        public AccountUserController(UserManager<AccountUser> usermanager, SignInManager<AccountUser> signInManager)
        {
            UserMgr = usermanager;
            SignInMgr = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction(DIRECT_ACTN, DIRECT_CNTR);
        }

    }
}
