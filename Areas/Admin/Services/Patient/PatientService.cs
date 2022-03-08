using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public class PatientService : IPatientService
    {
        internal IGatewayManager gatewayManager;
        public PatientService(IGatewayManager gatewayManager)
        {
            this.gatewayManager = gatewayManager;
        }
        public void CreatePatient(Patient patient)
        {
            gatewayManager.PatientGateway.Add(patient);
        }

        public void DeletePatient(Guid id)
        {
            gatewayManager.PatientGateway.Delete(id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return gatewayManager.PatientGateway.GetAll();
        }

        public Patient GetPatient(Guid id)
        {
            return gatewayManager.PatientGateway.FindById(id);
        }

        public void SavePatient()
        {
            gatewayManager.Save();
        }

        public void UpdatePatient(Patient patient)
        {
            gatewayManager.PatientGateway.Update(patient);
        }

    }
}
