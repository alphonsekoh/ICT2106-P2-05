using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BC = BCrypt.Net.BCrypt;
using Org.BouncyCastle.Crypto.Generators;

namespace PainAssessment.Domain
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User myUser = User.GetInstance;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Login(string username, string password)
        {

            /*
             * Left one part to show the need of singleton pattern in User class
             * 
             */

            IEnumerable<Account> account = _unitOfWork.LoginRepository.Find(Acc => Acc.Username.Equals(username));
            // Check if account exists and password matches to the one in db
            Account userAcc = account.FirstOrDefault();
            if (userAcc != null && BC.Verify(password, userAcc.Password))
            {
                Account user = _unitOfWork.LoginRepository.GetById<Account, Guid>(userAcc.AccountId);

                myUser.setProperty(user.AccountId, user.Role);

                return myUser;
            }
            else
            {
                return null;
            }
        }

        public string GetRole()
        {
            return myUser.GetRole;

        }

        public Guid GetAccountId()
        {
            return myUser.GetGuid;
        }

        public bool CheckInstance()
        {
            if (User.GetInstance != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string IsFirstSignIn(Guid accountId)
        {
            Account user = _unitOfWork.LoginRepository.GetById<Account, Guid>(accountId);
            if (user != null)
            {
                if (user.FirstSignIn.Equals(true))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return null;
            }

        }

        public void setFirstSignInFalse(Account account)
        {
            _unitOfWork.AccountRepository.Update(account);
            _unitOfWork.Save();
        }

        public Account GetAccount(Guid accountId)
        {
            Account user = _unitOfWork.LoginRepository.GetById<Account, Guid>(accountId);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

    }
}
