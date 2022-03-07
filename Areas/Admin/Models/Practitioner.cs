using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class Practitioner
    {
        public Guid PractitionerID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public string Experience { get; private set; }
        public string PracticeType { get; private set; }
        public string PriorPainEducation { get; private set; }
        public int ClinicalAreaID { get; private set; }
        public ClinicalArea ClinicalArea { get; private set; }

        private readonly List<Patient> _patients = new List<Patient>();
        public virtual IReadOnlyList<Patient> Patients => _patients.ToList();

        private readonly List<PractitionerPatient> _practitionerPatients = new List<PractitionerPatient>();

        public Practitioner(string name, string experience, string practiceType, string priorPainEducation, int clinicalAreaID)
        {
            Name = name;
            Experience = experience;
            PracticeType = practiceType;
            PriorPainEducation = priorPainEducation;
            ClinicalAreaID = clinicalAreaID;
        }

        public Practitioner( string name, string experience, string practiceType, string priorPainEducation, int clinicalAreaID, Guid practitionerID)
        {
            PractitionerID = practitionerID;
            Name = name;
            Experience = experience;
            PracticeType = practiceType;
            PriorPainEducation = priorPainEducation;
            ClinicalAreaID = clinicalAreaID;
        }

        public virtual IReadOnlyList<PractitionerPatient> PractitionerPatients => _practitionerPatients.ToList();
    }
}



