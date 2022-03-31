using PainAssessment.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    public interface ILoginService
    {
        User Login(string username, string password);

        //bool VerifyHash(string unhashedValue, string hashedValue);

        //string HashValue(string input);

        // get role
        string GetRole(Guid accountId);
        bool CheckInstance();
        void setFirstSignInFalse(Account account);
        string IsFirstSignIn(Guid accountId);
        Account GetAccount(Guid accountId);
    }
}
