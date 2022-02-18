using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public class DepartmentService : IDepartmentService
    {
        internal IUnitOfWork unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }
        public void CreateDepartment(Department department)
        {
            unitOfWork.DepartmentGateway.Add(department);
        }

        public void DeleteDepartment(int id)
        {
            unitOfWork.DepartmentGateway.Delete(id);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return unitOfWork.DepartmentGateway.GetAll();
        }

        public Department GetDepartment(int id)
        {
            return unitOfWork.DepartmentGateway.FindById(id);
        }

        public void SaveDepartment()
        {
            unitOfWork.Save();
        }

        public void UpdateDepartment(Department department)
        {
            unitOfWork.DepartmentGateway.Update(department);
        }


        
    }
}
