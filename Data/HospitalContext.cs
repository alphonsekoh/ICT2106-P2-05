using Microsoft.EntityFrameworkCore;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<TemplateChecklist> TemplateChecklists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);
            modelBuilder.Entity<Administrator>().HasKey(a => a.AccountId);
            modelBuilder.Entity<Practitioner>().HasKey(p => p.AccountId);
        }
    }
}
