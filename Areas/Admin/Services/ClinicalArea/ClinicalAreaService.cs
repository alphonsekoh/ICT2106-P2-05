using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public class ClinicalAreaService : IClinicalAreaService
    {
        internal IGatewayManager gatewayManager;
        public ClinicalAreaService(IGatewayManager gatewayManager)
        {
            this.gatewayManager = gatewayManager;
        }
        public void CreateClinicalArea(ClinicalArea clinicalArea)
        {
            gatewayManager.ClinicalAreaGateway.Add(clinicalArea);
        }

        public void DeleteClinicalArea(int id)
        {
            gatewayManager.ClinicalAreaGateway.Delete(id);
        }

        public IEnumerable<ClinicalArea> GetAllClinicalAreas()
        {
            return gatewayManager.ClinicalAreaGateway.GetAll();
        }

        public ClinicalArea GetClinicalArea(int id)
        {
            return gatewayManager.ClinicalAreaGateway.FindById(id);
        }

        public void SaveClinicalArea()
        {
            gatewayManager.Save();
        }

        public void UpdateClinicalArea(ClinicalArea clinicalArea)
        {
            gatewayManager.ClinicalAreaGateway.Update(clinicalArea);
        }

    }
}
