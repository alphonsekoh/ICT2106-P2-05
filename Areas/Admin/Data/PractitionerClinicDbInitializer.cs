using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data
{
    public static class PractitionerClinicDbInitializer
    {
        public static void Initialize(HospitalContext context)
        {
            //context.Database.EnsureCreated();
            // Look for any practitioner
            if (context.Practitioners.Any())
            {
                return;   // DB has been seeded
            }
            var departments = new ClinicalArea[]
            {
            new ClinicalArea{Name="Musculoskeletal"},
            new ClinicalArea{Name="Neurology/Neurosurgery"},
            new ClinicalArea{Name="Older People/Falls"},
            new ClinicalArea{Name="Cardiorespiratory"},
            new ClinicalArea{Name="Women’s Health/Pelvic Floor"},
            new ClinicalArea{Name="General Medicine"},
            new ClinicalArea{Name="Orthopaedic"},            
            new ClinicalArea{Name="Pain Management"},
            new ClinicalArea{Name="Intensive Care"},
            new ClinicalArea{Name="Hand Therapy"},
            };

            context.ClinicalAreas.AddRange(departments);

            context.SaveChanges();

            var practitioners = new Practitioner[]
            {
            new Practitioner{ClinicalAreaID=1,Name="Alexander"},
            new Practitioner{ClinicalAreaID=2,Name="Meredith"},
            new Practitioner{ClinicalAreaID=2,Name="Carson"},
            new Practitioner{ClinicalAreaID=2,Name="Arturo"},
            new Practitioner{ClinicalAreaID=3,Name="Gytis"},
            new Practitioner{ClinicalAreaID=3,Name="Yan"},
            new Practitioner{ClinicalAreaID=3,Name="Li"},
            new Practitioner{ClinicalAreaID=4,Name="Alonso"},
            new Practitioner{ClinicalAreaID=4,Name="Anand"},
            new Practitioner{ClinicalAreaID=4,Name="Barzdukas"},
            new Practitioner{ClinicalAreaID=4,Name="Olivetto"},
            new Practitioner{ClinicalAreaID=5,Name="Nino"},
            new Practitioner{ClinicalAreaID=5,Name="Peggy"},
            new Practitioner{ClinicalAreaID=5,Name="Laura"},
            new Practitioner{ClinicalAreaID=5,Name="Norman"},
            new Practitioner{ClinicalAreaID=5,Name="Justice"},
            new Practitioner{ClinicalAreaID=6,Name="Liam"},
            new Practitioner{ClinicalAreaID=6,Name="Oliver"},
            new Practitioner{ClinicalAreaID=6,Name="Elijah"},
            new Practitioner{ClinicalAreaID=6,Name="William"},
            new Practitioner{ClinicalAreaID=6,Name="James"},
            new Practitioner{ClinicalAreaID=6,Name="Benjamin"},
            new Practitioner{ClinicalAreaID=7,Name="Lucas"},
            };
            context.Practitioners.AddRange(practitioners);

            context.SaveChanges();



            var patients = new Patient[]
            {
                new Patient{ Name= "Stone", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "John", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Wong", BirthDate=DateTime.UtcNow, Gender="Male", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Mia", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Nguta", BirthDate=DateTime.UtcNow, Gender="Male", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Ilya", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Ellawala", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Ruveni", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Ponnappa", BirthDate=DateTime.UtcNow, Gender="Male", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Priya", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Peter", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Stanbridge", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Ruveni", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Andrews", BirthDate=DateTime.UtcNow, Gender="Male", Condition = "Unknown", Notes = "Unknown" },
                new Patient{ Name= "Daly", BirthDate=DateTime.UtcNow, Gender="Female", Condition = "Unknown", Notes = "Unknown" }

            };
            context.Patients.AddRange(patients);
            context.SaveChanges();

        }
    }
}
