using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class MvcConsultationChecklistContext : DbContext
    {
        public MvcConsultationChecklistContext(DbContextOptions<MvcConsultationChecklistContext> options)
            : base(options)
        {
        }

        public DbSet<Checklist> ConsultationChecklist { get; set; }
        public DbSet<Checklist> ConsultationCentralDomain { get; set; }
        public DbSet<Checklist> ConsultationRegionalDomain { get; set; }
        public DbSet<Checklist> ConsultationLocalDomain { get; set; }
    }
}
