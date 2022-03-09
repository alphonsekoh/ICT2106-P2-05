using PainAssessment.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    public interface ILoginService
    {
        User Login(string username, string password);
        void UpdatePassword(string username, string password, string confirmPassword);
    }
}
