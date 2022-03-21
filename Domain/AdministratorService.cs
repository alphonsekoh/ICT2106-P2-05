﻿using PainAssessment.Interfaces;
using PainAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Domain
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministratorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create Admin
        public void CreateAdmin(Administrator admin)
        {
            _unitOfWork.AdministratorRepository.Add(admin);
            _unitOfWork.Save();
        }

        // Get one Admin
        public Administrator GetOneAdmin(string username)
        {
            IEnumerable<Account> account = _unitOfWork.AccountRepository.Find(Acc => Acc.Username.Equals(username));
            Account userAcc = account.First();
            IEnumerable<Administrator> admin = _unitOfWork.AdministratorRepository.Find(Acc => Acc.Account.AccountId.Equals(userAcc.AccountId));
            Administrator adminAcc = admin.First();
            Administrator adminDetails = _unitOfWork.AdministratorRepository.GetById<Administrator,Guid>(adminAcc.AdminId);
            return adminDetails;
        }

        // Get all Admin
        public Administrator GetAllAdmin()
        {
            return (Administrator)_unitOfWork.AdministratorRepository.GetAll();
        }


        // Update Admin
        public void UpdateAdmin(Administrator admin)
        {
            _unitOfWork.AdministratorRepository.Update(admin);
            _unitOfWork.Save();
        }

        // Delete Admin
        public void DeleteAdmin(int id)
        {
            _unitOfWork.AdministratorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
