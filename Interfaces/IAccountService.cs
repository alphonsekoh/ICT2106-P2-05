using PainAssessment.Models;

namespace PainAssessment.Interfaces
{
    public interface IAccountService
    {
        void UpdatePassword(string username, string password, string confirmPassword);
        void CreateAcc(Account account);
        bool CheckUsername(string username);
    }
}
