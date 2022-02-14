using PainAssessment.Areas.Admin.Data.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentGateway DepartmentGateway { get; }
        IPatientGateway PatientGateway { get; }
        IPractitionerGateway PractitionerGateway { get; }
        void Save();
    }
}
