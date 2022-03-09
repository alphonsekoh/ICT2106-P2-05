using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Linq;


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
            ClinicalArea[] departments = new ClinicalArea[]
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
            new Practitioner("Alexander", "2 years ", "Hospital Inpatient", "Pre-registration training - pain topics",1),
            new Practitioner( "Meredith", "2 years ", "Hospital Inpatient", "Pre-registration training - pain topics",1),
            new Practitioner( "Carson", "4 years ", "Hospital Inpatient",  "Inservice",2),
            new Practitioner( "Arturo", "4 years ", "Hospital Outpatient",  "Inservice",2),
            new Practitioner( "Gytis", "6 years ", "Hospital Outpatient", "Professional Body",3),
            new Practitioner( "Yan", "6 years ", "Hospital Outpatient", "Professional Body, Postgraduate qualification pain-specific",3),
            new Practitioner( "Li", "6 years ", "Hospital Outpatient", "Pre-registration training - pain topics",4),
            new Practitioner( "Alonso", "None", "Community Health", "Professional Body, Postgraduate qualification pain-specific",4),
            new Practitioner( "Anand", "1 year", "Community Health", "Pre-registration training - pain topics",5),
            new Practitioner( "Barzdukas", "2 years ", "Community Health", "Pre-registration training - pain topics",5),
            new Practitioner( "Olivetto", "2 years ", "Rehabilitation Clinic", "Pre-registration training - pain topics",6),
            new Practitioner( "Nino", "3 years ", "Rehabilitation Clinic", "Professional Body, Postgraduate qualification not pain-specific",6),
            new Practitioner( "Peggy", "3 years ", "Rehabilitation Clinic", "Pre-registration training - pain topics",4),
            new Practitioner( "Laura", "3 years ", "Private clinic", "Conference (not pain specific)",7),
            new Practitioner( "Norman", "6 years ",  "Private clinic", "Conference (not pain specific)",7),
            new Practitioner( "Justice", "6 years ",  "Private clinic", "Pre-registration training - pain topics",8),
            new Practitioner( "Liam", "8 years ",  "Private clinic", "Private provider course or workshop",8),
            new Practitioner( "Oliver", "8 years ",  "Private clinic", "Pre-registration training - pain topics",3),
            new Practitioner( "Elijah", "9 years ",  "Private clinic", "Conference (pain specific)",9),
            new Practitioner( "William", "9 years ", "Private clinic", "Conference (pain specific)",9),
            new Practitioner( "James", "3 years ",  "Private clinic", "Pre-registration training - pain topics",10),
            new Practitioner( "Benjamin", "1 years ", "Private clinic", "None",10),
            new Practitioner( "Lucas", "1 years ", "Private clinic", "None",10),
            });

            context.SaveChanges();

            Patient[] patients = new Patient[]
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
