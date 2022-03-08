using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            } else
            {
                return new Patient(name, gender, birthDate, condition, notes, (Guid)id);
            }
        }

        public IPractitioner CreatePractitioner(string name, string experience, string practiceType, string priorPainEducation, int clinicalAreaID, Guid? id = null)
        {
            if (id == null)
            {
                return new Practitioner(name.ToString(), experience.ToString(), practiceType.ToString(), priorPainEducation.ToString(), clinicalAreaID);

            }
            else
            {
                return new Practitioner(name.ToString(), experience.ToString(), practiceType.ToString(), priorPainEducation.ToString(), clinicalAreaID, (Guid)id);
            }
        }
    }
}
