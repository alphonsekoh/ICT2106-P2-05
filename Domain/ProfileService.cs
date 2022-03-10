using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Domain
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(int accountId)
        {
            // Implement here
            User useracc = _unitOfWork.UserRepository.GetById(accountId);
            return useracc;
        }
    }
}

