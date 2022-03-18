using PainAssessment.Interfaces;
using PainAssessment.Models;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Domain
{
    public class AdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministratorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create Admin
        public void CreateAdmin(Administrator admin)
        {
            _unitOfWork.AdministratorRepository.Add(admin);
            _unitOfWork.Save();
        }
    }
}
