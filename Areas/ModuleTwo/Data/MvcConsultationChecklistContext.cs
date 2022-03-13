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

        public DbSet<ConsultationChecklist> ConsultationChecklist { get; set; }
        public DbSet<ConsultationChecklist> ConsultationCentralDomain { get; set; }
        public DbSet<ConsultationChecklist> ConsultationRegionalDomain { get; set; }
        public DbSet<ConsultationChecklist> ConsultationLocalDomain { get; set; }
    }
}
