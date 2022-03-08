using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;

namespace PainAssessment.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
        public DbSet<ClinicalArea> ClinicalAreas { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PractitionerPatient> PractitionerPatients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //1. Use EntityFrameworkCoreExtensions (add DynamicDataMasking support)
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);

        }
    }
}
