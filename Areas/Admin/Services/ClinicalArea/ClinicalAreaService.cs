using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public class ClinicalAreaService : IClinicalAreaService
    {
        internal IUnitOfWork unitOfWork;
        public ClinicalAreaService(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }
        public void CreateClinicalArea(ClinicalArea department)
        {
            unitOfWork.ClinicalAreaGateway.Add(department);
        }

        public void DeleteClinicalArea(int id)
        {
            unitOfWork.ClinicalAreaGateway.Delete(id);
        }

        public IEnumerable<ClinicalArea> GetAllClinicalAreas()
        {
            return unitOfWork.ClinicalAreaGateway.GetAll();
        }

        public ClinicalArea GetClinicalArea(int id)
        {
            return unitOfWork.ClinicalAreaGateway.FindById(id);
        }

        public void SaveClinicalArea()
        {
            unitOfWork.Save();
        }

        public void UpdateClinicalArea(ClinicalArea department)
        {
            unitOfWork.ClinicalAreaGateway.Update(department);
        }


        
    }
}
