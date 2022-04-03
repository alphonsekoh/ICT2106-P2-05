using PainAssessment.Models;

namespace PainAssessment.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(string username);
        void UpdatePassword(Account account);
        void CreateAcc(Account account);
        bool CheckUsername(string username);
    }
}
