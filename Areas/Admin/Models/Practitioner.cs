using System;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Models
{
    public class Practitioner : Person, IPractitioner
    {
        public string Experience { get; private set; }
        public string PriorPainEducation { get; private set; }
        public int ClinicalAreaID { get; private set; }

        public ClinicalArea ClinicalArea { get; private set; }

        public int PracticeTypeID { get; private set; }

        public PracticeType PracticeType { get; private set; }

        private readonly List<Patient> _patients = new();
        public virtual IReadOnlyList<Patient> Patients => _patients.ToList();

        private readonly List<PractitionerPatient> _practitionerPatients = new();
        public virtual IReadOnlyList<PractitionerPatient> PractitionerPatients => _practitionerPatients.ToList();

        public Practitioner(string name, string experience, string priorPainEducation, int clinicalAreaID, int practiceTypeID)
        {
            Name = name;
            Experience = experience;
            PriorPainEducation = priorPainEducation;
            ClinicalAreaID = clinicalAreaID;
            PracticeTypeID = practiceTypeID;
        }

        public Practitioner(string name, string experience, string priorPainEducation, int clinicalAreaID, int practiceTypeID, Guid practitionerID)
        {
            Id = practitionerID;
            Name = name;
            Experience = experience;
            PriorPainEducation = priorPainEducation;
            ClinicalAreaID = clinicalAreaID;
            PracticeTypeID = practiceTypeID;
        }


        public void AddPatientRelation(Patient patient)
        {
            _patients.Add(patient);
        }
    }
}



