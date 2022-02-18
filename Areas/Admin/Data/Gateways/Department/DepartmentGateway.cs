using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public class DepartmentGateway : IDepartmentGateway
    {
        internal HospitalContext context;

        public DepartmentGateway(HospitalContext context)
        {
            this.context = context;
        }
        public void Add(Department department)
        {
            context.Departments.Add(department);
        }

        public void Delete(int id)
        {
            Department department = context.Departments.Find(id);
            context.Departments.Remove(department);
        }

        public Department FindById(int id)
        {
            return context.Departments.Include(d=>d.Practitioners).Where(d=> d.DepartmentID == id ).FirstOrDefault();
        
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public void Update(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
        }
    }
}
