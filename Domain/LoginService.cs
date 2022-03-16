using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
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

        public Account Login(string username, string password)
        {
            IEnumerable<Account> account = _unitOfWork.LoginRepository.Find(Acc=> Acc.Username.Equals(username));
            //Account account = _unitOfWork.AccountRepository.GetById(accountId);
            // Check if account exists and password matches to the one in db
            //if (account != null && BC.Verify(password, account.Password))
            Account userAcc = account.First();
            if (userAcc != null && password == userAcc.Password)
            {
                Account user = _unitOfWork.LoginRepository.GetById<Account, Guid>(userAcc.AccountId);
                return user;
            }
            else
            {
                return null;
            }

        }

    }
}
