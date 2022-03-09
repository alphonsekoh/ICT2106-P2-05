using System;

namespace PainAssessment.Areas.Admin.Models.Factory
{
    public class PersonFactory : IPersonFactory
    {
        public PersonFactory()
        {
            // Nothing...
        }

        public IPatient CreatePatient(string name, string gender, DateTime birthDate, string condition, string notes, Guid? id = null)
        {
            if (id == null)
            {
                return new Patient(name, gender, birthDate, condition, notes);

            }
            else
            {
                return new Patient(name, gender, birthDate, condition, notes, (Guid)id);
            }
        }

        public IPractitioner CreatePractitioner(string name, string experience, string priorPainEducation, int clinicalAreaID, int practiceTypeID, Guid? id = null)
        {
            if (id == null)
            {
                return new Practitioner(name.ToString(), experience.ToString(), priorPainEducation.ToString(), clinicalAreaID, practiceTypeID);

            }
            else
            {
                return new Practitioner(name.ToString(), experience.ToString(), priorPainEducation.ToString(), clinicalAreaID, practiceTypeID, (Guid)id);
            }
        }
    }
}
