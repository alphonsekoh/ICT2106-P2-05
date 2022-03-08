using PainAssessment.Areas.Admin.Data.Gateways;
using System;

namespace PainAssessment.Areas.Admin.Data
{
    public interface IGatewayManager : IDisposable
    {
        IClinicalAreaGateway ClinicalAreaGateway { get; }
        IPatientGateway PatientGateway { get; }
        IPractitionerGateway PractitionerGateway { get; }
        public void Save();
    }
}
