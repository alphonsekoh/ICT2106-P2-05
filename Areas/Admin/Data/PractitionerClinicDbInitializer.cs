using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Util;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            context.Practitioners.AddRange(new Practitioner[]
            {
            new Practitioner{ ClinicalAreaID=1, Name="Alexander", Experience="2 years ", PracticeType ="Hospital Inpatient", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=2, Name="Meredith", Experience="2 years ", PracticeType ="Hospital Inpatient", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=2, Name="Carson", Experience="4 years ", PracticeType ="Hospital Inpatient",  PriorPainEducation ="Inservice"},
            new Practitioner{ ClinicalAreaID=2, Name="Arturo", Experience="4 years ", PracticeType ="Hospital Outpatient",  PriorPainEducation ="Inservice"},
            new Practitioner{ ClinicalAreaID=3, Name="Gytis", Experience="6 years ", PracticeType ="Hospital Outpatient", PriorPainEducation ="Professional Body"},
            new Practitioner{ ClinicalAreaID=3, Name="Yan", Experience="6 years ", PracticeType ="Hospital Outpatient", PriorPainEducation ="Professional Body, Postgraduate qualification pain-specific"},
            new Practitioner{ ClinicalAreaID=3, Name="Li", Experience="6 years ", PracticeType ="Hospital Outpatient", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=4, Name="Alonso", Experience="None", PracticeType ="Community Health", PriorPainEducation ="Professional Body, Postgraduate qualification pain-specific"},
            new Practitioner{ ClinicalAreaID=4, Name="Anand", Experience="1 year", PracticeType ="Community Health", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=4, Name="Barzdukas", Experience="2 years ", PracticeType ="Community Health", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=4, Name="Olivetto", Experience="2 years ", PracticeType ="Rehabilitation Clinic", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=5, Name="Nino", Experience="3 years ", PracticeType ="Rehabilitation Clinic", PriorPainEducation ="Professional Body, Postgraduate qualification not pain-specific"},
            new Practitioner{ ClinicalAreaID=5, Name="Peggy", Experience="3 years ", PracticeType ="Rehabilitation Clinic", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=5, Name="Laura", Experience="3 years ", PracticeType ="Private clinic", PriorPainEducation ="Conference (not pain specific)"},
            new Practitioner{ ClinicalAreaID=5, Name="Norman", Experience="6 years ",  PracticeType ="Private clinic", PriorPainEducation ="Conference (not pain specific)"},
            new Practitioner{ ClinicalAreaID=5, Name="Justice", Experience="6 years ",  PracticeType ="Private clinic", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=6, Name="Liam", Experience="8 years ",  PracticeType ="Private clinic", PriorPainEducation ="Private provider course or workshop"},
            new Practitioner{ ClinicalAreaID=6, Name="Oliver", Experience="8 years ",  PracticeType ="Private clinic", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=6, Name="Elijah", Experience="9 years ",  PracticeType ="Private clinic", PriorPainEducation ="Conference (pain specific)"},
            new Practitioner{ ClinicalAreaID=6, Name="William", Experience="9 years ", PracticeType ="Private clinic", PriorPainEducation ="Conference (pain specific)"},
            new Practitioner{ ClinicalAreaID=6, Name="James", Experience="3 years ",  PracticeType ="Private clinic", PriorPainEducation ="Pre-registration training - pain topics"},
            new Practitioner{ ClinicalAreaID=6, Name="Benjamin", Experience="1 years ", PracticeType ="Private clinic", PriorPainEducation ="None"},
            new Practitioner{ ClinicalAreaID=7, Name="Lucas", Experience="1 years ", PracticeType ="Private clinic", PriorPainEducation ="None"},
            });

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

            foreach (Patient p in patients)
            {
                p.Name = Regex.Replace(p.Name, @"\b\w{3,}\b", match => Utility.MaskName(match.Value));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

        }
    }
}
