using System;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    interface IAdminBuilder
    {
        IAdminBuilder WithId(Guid id);
        IAdminBuilder WithName(string name);
        IAdminBuilder WithFullName(string fullName);
        IAdminBuilder WithRole(string role);
        IAdminBuilder WithExperience(string experience);
        IAdminBuilder WithClinic(int clinicId);
        IAdminBuilder WithDOB(DateTime dob);

        Administrator Build();
    }
}
