using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPractitionerService
    {
        Practitioner GetPractitioner(int id);
        IEnumerable<Practitioner> GetAllPractitioners();
        IEnumerable<Practitioner> GetAllPractitionersByPage(int page);
        void CreatePractitioner(Practitioner practitioner);
        void UpdatePractitioner(Practitioner practitioner);
        void DeletePractitioner(int id);

        void SavePractitioner();
    }
}
