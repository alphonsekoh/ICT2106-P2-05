using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Domain
{
    public class AccountService:iProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Account GetAccount(int accountID)
        {
            return _unitOfWork.AccountRepository.GetById(accountID);
        }
 
        public void UpdateAccount(int accountID,string name, string username, string password, string role, int departmentId)
        {
            Account acc = GetAccount(accountID);
            acc.Name = name;
            acc.Username = username;
            acc.Password = password;
            acc.Role = role;
            acc.DepartmentId = departmentId;
            _unitOfWork.Save();
        }

    }
}
