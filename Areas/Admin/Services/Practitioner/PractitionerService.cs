using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public class PractitionerService : IPractitionerService
    {
        internal IGatewayManager gatewayManager;
        public PractitionerService(IGatewayManager gatewayManager)
        {
            this.gatewayManager = gatewayManager;
        }
        public void CreatePractitioner(Practitioner practitioner)
        {
            gatewayManager.PractitionerGateway.Add(practitioner);
        }

        public void DeletePractitioner(Guid id)
        {
            gatewayManager.PractitionerGateway.Delete(id);
        }

        public IEnumerable<Practitioner> GetAllPractitioners()
        {
            return gatewayManager.PractitionerGateway.GetAll();
        }

        public Practitioner GetPractitioner(Guid id)
        {
            return gatewayManager.PractitionerGateway.FindById(id);
        }

        public void SavePractitioner()
        {
            gatewayManager.Save();
        }

        public void UpdatePractitioner(Practitioner practitioner)
        {
            gatewayManager.PractitionerGateway.Update(practitioner);
        }
    }
}