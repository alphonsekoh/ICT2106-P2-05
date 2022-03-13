using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class MvcChecklistContext : DbContext
    {
        public MvcChecklistContext(DbContextOptions<MvcChecklistContext> options)
            : base(options)
        {
        }

        public DbSet<Checklist> Checklist { get; set; }
        public DbSet<CentralDomain> CentralDomain { get; set; }
        public DbSet<RegionalDomain> RegionalDomain { get; set; }
        public DbSet<LocalDomain> LocalDomain { get; set; }
    }
}
