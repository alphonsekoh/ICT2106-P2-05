using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public class PatientService : IPatientService
    {
        internal IUnitOfWork unitOfWork;
        public PatientService(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }
        public void CreatePatient(Patient patient)
        {
            unitOfWork.PatientGateway.Add(patient);
        }

        public void DeletePatient(Guid id)
        {
            unitOfWork.PatientGateway.Delete(id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return unitOfWork.PatientGateway.GetAll();
        }

        public Patient GetPatient(Guid id)
        {
            return unitOfWork.PatientGateway.FindById(id);
        }

        public void SavePatient()
        {
            unitOfWork.Save();
        }

        public void UpdatePatient(Patient patient)
        {
            unitOfWork.PatientGateway.Update(patient);
        }

    }
}
