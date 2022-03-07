using PainAssessment.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    public interface ILoginService
    {
        bool Login(int accountId, string password);
    }
}
