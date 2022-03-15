using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.Builder
{
    class PatientBuilder : IPatientBuilder
    {
        private Guid id;
        private string name;
        private DateTime birthDate;
        private string gender;
        private string condition;
        private string notes;

        public PatientBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public PatientBuilder WithBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
            return this;
        }

        public PatientBuilder WithCondition(string condition)
        {
            this.condition = condition;
            return this;
        }

        public PatientBuilder WithGender(string gender)
        {
            this.gender = gender;
            return this;

        }



        public PatientBuilder WithNotes(string notes)
        {
            this.notes = notes;
            return this;
        }

        public PatientBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public Patient Build()
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(name));
            }
            if (String.IsNullOrEmpty(gender))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(gender));
            }
            if (birthDate == default)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(gender));
            }
            if (id == default)
            {
                return new Patient(name, gender, birthDate, condition, notes);

            }
            else
            {
                return new Patient(name, gender, birthDate, condition, notes, id);
            }
        }
    }
}
