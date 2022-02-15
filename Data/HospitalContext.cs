using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Identity.Data;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Data
{
    public class HospitalContext : IdentityDbContext<IdentityUser>
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        public DbSet<AccountUser> Accounts { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<TemplateChecklist> TemplateChecklists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);
            modelBuilder.Entity<Administrator>().HasKey(a => a.AccountId);
            modelBuilder.Entity<Practitioner>().HasKey(p => p.AccountId);
        }
    }
}
