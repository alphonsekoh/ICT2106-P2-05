using System;

namespace PainAssessment.Areas.Admin.Models
{
    public class PractitionerPatient
    {
        public Guid PractitionerID { get; set; }
        public Guid PatientID { get; set; }

        public Practitioner Practitioner { get; private set; }
        public Patient Patient { get; private set; }

    }
}
