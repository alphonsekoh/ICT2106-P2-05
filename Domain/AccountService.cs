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

        public Account GetAccount(string username)
        {
            IEnumerable<Account> account = _unitOfWork.AccountRepository.Find(Acc => Acc.Username.Equals(username));
            Account userAcc = account.First();
            if (userAcc != null)
            {
                return userAcc;
            }
            else return null;
        }

        // Update Password
        public void UpdatePassword(Account account)
        {
            _unitOfWork.AccountRepository.Update(account);
            _unitOfWork.Save();

        }

        // Reset Password (might use email??)


        // Update AccountStatus
        public void UpdateAccountStatus(Account account)
        {

        }


        // Create Account
        public void CreateAcc(Account account)
        {
            _unitOfWork.AccountRepository.Add(account);
            _unitOfWork.Save();
        }

        // Check Duplicate Username
        public bool CheckUsername(string username)
        {
            IEnumerable<Account> account = _unitOfWork.AccountRepository.Find(Acc => Acc.Username.Equals(username));

            if (account.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
