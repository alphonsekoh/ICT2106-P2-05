using System;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    class AdminBuilder : IAdminBuilder
    {
        private Guid id;
        private string fullName;
        private string name;
        private string role;
        private string experience;
        private int clinicId;
        private DateTime dob;


        public IAdminBuilder WithClinic(int clinicId)
        {
            this.clinicId = clinicId;
            return this;
        }

        public IAdminBuilder WithExperience(string experience)
        {
            this.experience = experience;
            return this;
        }

        public IAdminBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public IAdminBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public IAdminBuilder WithFullName(string fullName)
        {
            this.fullName = fullName;
            return this;
        }
        public IAdminBuilder WithRole(string role)
        {
            this.role = role;
            return this;
        }
        public IAdminBuilder WithDOB(DateTime dob)
        {
            this.dob = dob;
            return this;
        }

        public Administrator Build()
        {
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(fullName));
            }
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(name));
            }
            if (String.IsNullOrEmpty(role))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(role));
            }

            if (experience == default)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(experience));
            }

            if (clinicId == default)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(clinicId));
            }

            if (id == default)
            {
                return new Administrator(fullName, name,role, experience, clinicId);
            }
            else
            {
                return new Administrator(name, fullName, role, experience, clinicId, id);
            }
        }
    }
}
