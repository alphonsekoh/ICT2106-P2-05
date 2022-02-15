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
    }
}
