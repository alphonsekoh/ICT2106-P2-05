using Org.BouncyCastle.Crypto.Generators;
using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using BC = BCrypt.Net.BCrypt;

namespace PainAssessment.Domain
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Login(int accountId, string password)
        {

            Account account = _unitOfWork.AccountRepository.GetById(accountId);
            // Check if account exists and password matches to the one in db
            if (account != null || BC.Verify(password, account.Password))
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
