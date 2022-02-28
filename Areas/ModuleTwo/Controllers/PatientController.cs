using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Controllers
{
    [Area("ModuleTwo")]
    public class PatientController : Controller
    {
        private readonly MvcChecklistContext _context;

        public PatientController(MvcChecklistContext context)
        {
            _context = context;
        }

        // GET: ModuleTwo/Checklists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient.ToListAsync());
        }

       
    }
}
