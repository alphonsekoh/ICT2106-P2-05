using PainAssessment.Interfaces;
using PainAssessment.Models;
using System.Collections.Generic;
using System.Linq;
using BC = BCrypt.Net.BCrypt;
using Org.BouncyCastle.Crypto.Generators;

namespace PainAssessment.Domain
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Update Password
        public void UpdatePassword(string username, string password, string confirmPassword)
        {
            IEnumerable<Account> account = _unitOfWork.AccountRepository.Find(Acc => Acc.Username.Equals(username));
            Account userAcc = account.First();
            if (password.Equals(confirmPassword) && userAcc != null)
            {
                // Hash Password
                var cost = 16;
                userAcc.Password = BC.HashPassword(password, cost);
                _unitOfWork.AccountRepository.Update(userAcc);
                _unitOfWork.Save();
            }

        }

        // Reset Password


        // Update 


    }
}
