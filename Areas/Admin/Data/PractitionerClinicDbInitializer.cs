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
            new ClinicalArea("Musculoskeletal"),
            new ClinicalArea("Neurology/Neurosurgery"),
            new ClinicalArea("Older People/Falls"),
            new ClinicalArea("Cardiorespiratory"),
            new ClinicalArea("Women’s Health/Pelvic Floor"),
            new ClinicalArea("General Medicine"),
            new ClinicalArea("Orthopaedic"),
            new ClinicalArea("Pain Management"),
            new ClinicalArea("Intensive Care"),
            new ClinicalArea("Hand Therapy"),
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
                new Patient(  "Stone","Female",DateTime.UtcNow,    "Unknown",  "Unknown" ),
                new Patient(  "John", "Female",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Wong", "Male",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Mia", "Female",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Nguta",  "Male",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Ilya",  "Female", DateTime.UtcNow, "Unknown",  "Unknown" ),
                new Patient(  "Ellawala",  "Female",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Ruveni",  "Female",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Ponnappa",  "Male",  DateTime.UtcNow,"Unknown",  "Unknown" ),
                new Patient(  "Priya",  "Female", DateTime.UtcNow, "Unknown",  "Unknown" ),
                new Patient(  "Peter",  "Female",  DateTime.UtcNow,"Unknown",  "Unknown" ),
                new Patient(  "Stanbridge",  "Female", DateTime.UtcNow, "Unknown",  "Unknown" ),
                new Patient(  "Ruveni",  "Female", DateTime.UtcNow, "Unknown",  "Unknown" ),
                new Patient(  "Andrews",  "Male",DateTime.UtcNow,  "Unknown",  "Unknown" ),
                new Patient(  "Daly",  "Female", DateTime.UtcNow, "Unknown",  "Unknown" )

            };

            context.Patients.AddRange(patients);
            context.SaveChanges();

        }
    }
}
