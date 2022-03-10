using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public class PracticeTypeService : IPracticeTypeService
    {
        internal IGatewayManager gatewayManager;
        public PracticeTypeService(IGatewayManager gatewayManager)
        {
            this.gatewayManager = gatewayManager;
        }
        public void CreatePracticeType(PracticeType practiceType)
        {
            gatewayManager.PracticeTypeGateway.Add(practiceType);
        }

        public void DeletePracticeType(int id)
        {
            gatewayManager.PracticeTypeGateway.Delete(id);
        }

        public IEnumerable<PracticeType> GetAllPracticeTypes()
        {
            return gatewayManager.PracticeTypeGateway.GetAll();
        }

        public PracticeType GetPracticeType(int id)
        {
            return gatewayManager.PracticeTypeGateway.FindById(id);
        }

        public void SavePracticeType()
        {
            gatewayManager.Save();
        }

        public void UpdatePracticeType(PracticeType practiceType)
        {
            gatewayManager.PracticeTypeGateway.Update(practiceType);
        }


    }
}
