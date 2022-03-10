using System;


namespace PainAssessment.Areas.Admin.Models.Factory
{
    interface IPersonFactory
    {
        Patient CreatePatient(string name, string gender, DateTime birthDate, string condition, string notes, Guid? patientID = null);
        Practitioner CreatePractitioner(string name, string experience, string priorPainEducation, int clinicalAreaID, int practiceTypeID, Guid? practitionerID = null);
    }
}
