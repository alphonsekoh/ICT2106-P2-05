using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public interface IPatient
    {
        public void AddPractitionerRelation(Practitioner practitioner);

    }
}
