using System;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    interface IPatientBuilder
    {
        IPatientBuilder WithName(string name);
        IPatientBuilder WithGender(string gender);
        IPatientBuilder WithAge(int age);
        IPatientBuilder WithCondition(string condition);
        IPatientBuilder WithNotes(string notes);
        IPatientBuilder WithId(Guid id);

        Patient Build();

    }
}
