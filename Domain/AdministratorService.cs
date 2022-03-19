using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Domain
{
    public class AdministratorService : IAdministratorService
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
