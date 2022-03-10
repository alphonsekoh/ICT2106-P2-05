using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IPatientGateway
    {
        void Add(Patient patient);
        Patient FindById(Guid id);
        IEnumerable<Patient> GetAll();
        void Update(Patient patient);
        void Delete(Guid id);
    }
}
