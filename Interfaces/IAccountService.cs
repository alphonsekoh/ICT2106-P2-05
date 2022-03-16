namespace PainAssessment.Interfaces
{
    public interface IAccountService
    {
        void UpdatePassword(string username, string password, string confirmPassword);
    }
}
