using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Models;

namespace PainAssessment.Interfaces
{
    public interface iProfileService
    {
        // Write all the functions controller can call e.g. CRUD
        Account GetAccount(int accountID);
        void UpdateAccount(int accountID, string name, string username, string password, string role, int departmentId);
    }
}
