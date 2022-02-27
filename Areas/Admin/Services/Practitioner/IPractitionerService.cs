using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPractitionerService
    {
        Practitioner GetPractitioner(Guid id);
        IEnumerable<Practitioner> GetAllPractitioners();
        IEnumerable<Practitioner> GetAllPractitionersByPageAndName(int page, string searchName);
        int GetPractitionersCount();
        void CreatePractitioner(Practitioner practitioner);
        void UpdatePractitioner(Practitioner practitioner);
        void DeletePractitioner(Guid id);

        void SavePractitioner();
    }
}
