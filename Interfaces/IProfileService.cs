using PainAssessment.Models;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    public interface IProfileService
    {
        User GetUser(int accountId);
    }
}
