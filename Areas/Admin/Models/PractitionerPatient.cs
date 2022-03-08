using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class PractitionerPatient
    {
        public Guid PractitionerID { get; private set; }
        public Guid PatientID { get; private set; }

        public Practitioner Practitioner { get;  private set; }
        public Patient Patient { get; private set; }

        public PractitionerPatient(Guid practitionerID, Guid patientID)
        {
            PractitionerID = practitionerID;
            PatientID = patientID;
        }
    }
}
