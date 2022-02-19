using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Data
{
    public class PainAssessmentContext : DbContext
    {
        public PainAssessmentContext (DbContextOptions<PainAssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<PainAssessment.Areas.ModuleTwo.Models.Checklist> Checklist { get; set; }
    }
}
