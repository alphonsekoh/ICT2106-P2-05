using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    interface IPractitionerBuilder
    {
        IPractitionerBuilder WithId(Guid id);
        IPractitionerBuilder WithName(string name);
        IPractitionerBuilder WithExperience(string experience);
        IPractitionerBuilder WithPainEducation(string education);

        IPractitionerBuilder WithClinic(int clinicId);

        IPractitionerBuilder WithPracticeType(int typeId);


        Practitioner Build();
    }
}
