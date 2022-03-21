using PainAssessment.Models;

namespace PainAssessment.Interfaces
{
    public interface IAdministratorService
    {
        void CreateAdmin(Administrator admin);
        Administrator GetOneAdmin(string username);
        Administrator GetAllAdmin();
        void UpdateAdmin(Administrator admin);
        void DeleteAdmin(int id);

    }
}
