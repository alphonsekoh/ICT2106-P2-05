
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PainAssessment.Areas.ModuleTwo.Data;
using System;
using System.Linq;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public static class ConsultationSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PatientContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PatientContext>>()))
            {
                // Look for any movies.
                if (context.Patient.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patient.AddRange(
                    new Patient
                    {
                        Date = DateTime.Parse("1989-2-12"),
                        SessionNo = 1,
                        LastVisit = DateTime.Parse("1989-2-12"),
                        ClinicalArea = "Seed Data Clinic Area",
                        CentralModulation = 2,
                        RegionalInfluence = 3,
                        LocalStimulation = 5
                    },

                    new Patient
                    {
                        Date = DateTime.Parse("1989-5-12"),
                        SessionNo = 1,
                        LastVisit = DateTime.Parse("1989-3-12"),
                        ClinicalArea = "Clinic AMK2",
                        CentralModulation = 2,
                        RegionalInfluence = 3,
                        LocalStimulation = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}