using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Areas.Admin.Models;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IDepartmentGateway
    {
        void Add(Department department);
        Department FindById(int id);
        IEnumerable<Department> GetAll();
        void Update(Department department);
        void Delete(int id);

    }
}
