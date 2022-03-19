using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class MvcPatientContext : DbContext
    {
        public MvcPatientContext(DbContextOptions<MvcPatientContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patient { get; set; }
    }
}
