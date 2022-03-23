using PainAssessment.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    public interface ILoginService
    {
        Account Login(string username, string password);

        //bool VerifyHash(string unhashedValue, string hashedValue);

        //string HashValue(string input);


        // get role


        // is user authenticated



    }
}
