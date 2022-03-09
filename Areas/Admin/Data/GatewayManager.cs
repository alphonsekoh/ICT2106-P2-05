using PainAssessment.Areas.Admin.Data.Gateways;
using PainAssessment.Data;
using System;

namespace PainAssessment.Areas.Admin.Data
{
    public class GatewayManager : IGatewayManager
    {

        internal HospitalContext context;
        public IClinicalAreaGateway clinicalAreaGateway;
        public IPracticeTypeGateway practiceTypeGateway;
        public IPatientGateway patientGateway;
        public IPractitionerGateway practitionerGateway;

        public GatewayManager(HospitalContext context)
        {
            this.context = context;
        }
        public IClinicalAreaGateway ClinicalAreaGateway
        {
            get
            {
                if (clinicalAreaGateway == null)
                {
                    clinicalAreaGateway = new ClinicalAreaGateway(context);
                }
                return clinicalAreaGateway;
            }
        }

        public IPracticeTypeGateway PracticeTypeGateway
        {
            get
            {
                if (practiceTypeGateway == null)
                {
                    practiceTypeGateway = new PracticeTypeGateway(context);
                }
                return practiceTypeGateway;
            }
        }

        public IPractitionerGateway PractitionerGateway
        {
            get
            {
                if (practitionerGateway == null)
                {
                    practitionerGateway = new PractitionerGateway(context);
                }
                return practitionerGateway;
            }
        }

        public IPatientGateway PatientGateway
        {
            get
            {
                if (patientGateway == null)
                {
                    patientGateway = new PatientGateway(context);
                }
                return patientGateway;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
