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
        public DbSet<CentralDomain> ConsultationCentralDomain { get; set; }
        public DbSet<RegionalDomain> ConsultationRegionalDomain { get; set; }
        public DbSet<LocalDomain> ConsultationLocalDomain { get; set; }
    }
}
