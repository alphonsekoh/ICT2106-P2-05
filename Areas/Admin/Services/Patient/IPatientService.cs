 using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPatientService
    {
        Patient GetPatient(Guid id);
        IEnumerable<Patient> GetAllPatients();
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Guid id);
        void SavePatient();

    }
}
