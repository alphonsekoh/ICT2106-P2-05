using Org.BouncyCastle.Crypto.Generators;
using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using BC = BCrypt.Net.BCrypt;
using System.Linq;

namespace PainAssessment.Domain
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Login(string username, string password)
        {
            IEnumerable<Account> account = _unitOfWork.AccountRepository.Find(Acc=> Acc.Username.Equals(username));
            //Account account = _unitOfWork.AccountRepository.GetById(accountId);
            // Check if account exists and password matches to the one in db
            //if (account != null && BC.Verify(password, account.Password))
            Account userAcc = account.First();
            if (userAcc != null && password == userAcc.Password)
            {
                User user = _unitOfWork.UserRepository.GetById(userAcc.AccountId);
                return user;
            }
            else
            {
                return null;
            }

        }

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

    }
}
