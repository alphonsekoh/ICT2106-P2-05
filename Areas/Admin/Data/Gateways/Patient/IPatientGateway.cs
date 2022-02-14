using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IPatientGateway
    {
        void Add(Patient patient);
        Patient FindById(int id);
        IEnumerable<Patient> GetAll();
        void Update(Patient patient);
        void Delete(int id);
    }
}
