using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class ConsultationContext : DbContext
    {
        public ConsultationContext(DbContextOptions<ConsultationContext> options)
            : base(options)
        {
        }

        public DbSet<Consultation> Patient { get; set; }
    }
}