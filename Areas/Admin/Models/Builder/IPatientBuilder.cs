using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    interface IPatientBuilder
    {
        PatientBuilder WithName(string name);
        PatientBuilder WithGender(string gender);
        PatientBuilder WithBirthDate(DateTime birthDate);
        PatientBuilder WithCondition(string condition);
        PatientBuilder WithNotes(string notes);
        PatientBuilder WithId(Guid id);
        
    }
}
