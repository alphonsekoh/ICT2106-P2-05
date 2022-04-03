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

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Account Login(string username, string password)
        {
            IEnumerable<Account> account = _unitOfWork.LoginRepository.Find(Acc => Acc.Username.Equals(username));
            // Check if account exists and password matches to the one in db
            Account userAcc = account.FirstOrDefault();
            if (userAcc != null && BC.Verify(password, userAcc.Password))
            {
                Account user = _unitOfWork.LoginRepository.GetById<Account, Guid>(userAcc.AccountId);
                return user;
            }
            else
            {
                return null;
            }

        }

        //public bool VerifyHash(string unhashedValue, string hashedValue)
        //{
        //    if (BC.Verify(unhashedValue, hashedValue).Equals(true))
        //    {
        //        return true;
        //    }
        //    else return false;
        //}

        //public string HashValue(string input)
        //{
        //    return BC.HashPassword(input);
        //}

    }
}
