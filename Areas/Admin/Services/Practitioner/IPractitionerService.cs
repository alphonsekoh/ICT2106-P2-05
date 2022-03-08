using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPractitionerService
    {
        Practitioner GetPractitioner(Guid id);
        IEnumerable<Practitioner> GetAllPractitioners();
        void CreatePractitioner(Practitioner practitioner);
        void UpdatePractitioner(Practitioner practitioner);
        void DeletePractitioner(Guid id);
        void SavePractitioner();
    }
}
