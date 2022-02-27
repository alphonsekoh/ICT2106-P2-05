using Microsoft.AspNetCore.Mvc;

namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class PatientController : Controller
    {
        // GET: ../ModuleTwo/Patient
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: ../ModuleTwo/Patient/Details
        public IActionResult Details()
        {
            return View();
        }
    }
}
