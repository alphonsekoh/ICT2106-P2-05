using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }
    }
}