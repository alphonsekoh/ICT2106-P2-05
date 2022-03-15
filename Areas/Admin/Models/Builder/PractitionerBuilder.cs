using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    class PractitionerBuilder : IPractitionerBuilder
    {
        private Guid id;
        private string name;
        private string experience;
        private string painEducation;
        private int clinicId;
        private int practiceTypeId;

        public IPractitionerBuilder WithClinic(int clinicId)
        {
            this.clinicId = clinicId;
            return this;
        }

        public IPractitionerBuilder WithExperience(string experience)
        {
            this.experience = experience;
            return this;
        }

        public IPractitionerBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public IPractitionerBuilder WithName(string name)
        {
            this.name  = name;
            return this;
        }

        public IPractitionerBuilder WithPainEducation(string education)
        {
            this.painEducation = education;
            return this;
        }

        public IPractitionerBuilder WithPracticeType(int typeId)
        {
            this.practiceTypeId = typeId;
            return this;
        }

        public Practitioner Build()
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(name));
            }

            if (String.IsNullOrEmpty(experience))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(experience));
            }
            if (String.IsNullOrEmpty(painEducation))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(painEducation));
            }

            if (clinicId == default)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(clinicId));
            }
            if (practiceTypeId == default)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(practiceTypeId));
            }

            if (id == default)
            {
                return new Practitioner(name, experience, painEducation, clinicId, practiceTypeId);
            }
            else
            {
                return new Practitioner(name, experience, painEducation, clinicId, practiceTypeId, id);
            }
        }
    }
}
