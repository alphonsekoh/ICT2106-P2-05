using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public class PainEducationService : IPainEducationService
    {
        internal IGatewayManager gatewayManager;
        public PainEducationService(IGatewayManager gatewayManager)
        {
            this.gatewayManager = gatewayManager;
        }
        public void CreatePainEducation(PainEducation painEducation)
        {
            gatewayManager.PainEducationGateway.Add(painEducation);
        }

        public void DeletePainEducation(int id)
        {
            gatewayManager.PainEducationGateway.Delete(id);
        }

        public IEnumerable<PainEducation> GetAllPainEducations()
        {
            return gatewayManager.PainEducationGateway.GetAll();
        }

        public PainEducation GetPainEducation(int id)
        {
            return gatewayManager.PainEducationGateway.FindById(id);
        }

        public void SavePainEducation()
        {
            gatewayManager.Save();
        }

        public void UpdatePainEducation(PainEducation painEducation)
        {
            gatewayManager.PainEducationGateway.Update(painEducation);
        }

    }
}
