using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Factory
{
    interface IPersonFactory
    {
        Patient CreatePatient(string name, string gender, DateTime birthDate, string condition, string notes, Guid? patientID = null);
        Practitioner CreatePractitioner(string name, string experience, string practiceType, string priorPainEducation, int clinicalAreaID, Guid? practitionerID = null);
    }
}
