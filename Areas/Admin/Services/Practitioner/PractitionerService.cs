using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public class PractitionerService : IPractitionerService
    {
        internal IUnitOfWork unitOfWork;
        public PractitionerService(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }
        public void CreatePractitioner(Practitioner practitioner)
        {
            unitOfWork.PractitionerGateway.Add(practitioner);
        }

        public void DeletePractitioner(int id)
        {
            unitOfWork.PractitionerGateway.Delete(id);
        }

        public IEnumerable<Practitioner> GetAllPractitioners()
        {
            return unitOfWork.PractitionerGateway.GetAll();
        }

        public Practitioner GetPractitioner(int id)
        {
            return unitOfWork.PractitionerGateway.FindById(id);
        }

        public void UpdatePractitioner(Practitioner practitioner)
        {
            unitOfWork.PractitionerGateway.Update(practitioner);
        }
    }
}
