using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PainAssessment.Data;
using System;
using System.Linq;
using PainAssessment.Areas.ModuleTwo.Data;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public static class PatientSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPatientContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPatientContext>>()))
            {
                // Look for any records
                if (context.Patient.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patient.AddRange(
                    new Patient
                    {
                        patientName = "Ivan Lee",
                        patientAge = 25,
                        gender = "Male",
                        condition = "Knee",
                        patientNotes="Insert notes here",
                        sessions = 3,
                        lastVisit = DateTime.Now
                    }
                    , new Patient
                    {
                        patientName = "Chris Bella",
                        patientAge = 9,
                        gender = "Female",
                        condition = "Head",
                        patientNotes = "Insert notes here",
                        sessions = 7,
                        lastVisit = DateTime.Parse("2022-2-12")
                    },
                    new Patient
                    {
                        patientName = "Francis Tan",
                        patientAge = 22,
                        gender = "Male",
                        condition = "Shoulders",
                        patientNotes = "Insert notes here",
                        sessions = 4,
                        lastVisit = DateTime.Parse("2019-2-02")
                    },
                    new Patient
                    {
                        patientName = "Ivan Lee",
                        patientAge = 25,
                        gender = "Male",
                        condition = "Knee",
                        patientNotes = "Insert notes here",
                        sessions = 3,
                        lastVisit = DateTime.Parse("2020-4-12")
                    },
                    new Patient
                    {
                        patientName = "Sean Chew",
                        patientAge = 16,
                        gender = "Male",
                        condition = "Toes",
                        patientNotes = "Insert notes here",
                        sessions = 3,
                        lastVisit = DateTime.Parse("2021-8-30")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
