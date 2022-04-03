using PainAssessment.Models;
using System;

namespace PainAssessment.Interfaces
{
    public interface IAdministratorService
    {
        void CreateAdmin(Administrator admin);
        Administrator GetOneAdmin(Guid id);
        Administrator GetAllAdmin();
        void UpdateAdmin(Administrator admin);
        void DeleteAdmin(int id);

    }
}
