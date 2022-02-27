using PainAssessment.Areas.Admin.Data.Gateways;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        internal HospitalContext context;
        public IClinicalAreaGateway clinicalAreaGateway;
        public IPatientGateway patientGateway;
        public IPractitionerGateway practitionerGateway;

        public UnitOfWork(HospitalContext context)
        {
            this.context = context;
        }
        public IClinicalAreaGateway ClinicalAreaGateway
        {
            get
            {
                if (this.clinicalAreaGateway == null)
                {
                    clinicalAreaGateway = new ClinicalAreaGateway(context);
                }
                return clinicalAreaGateway;
            }
        }

        public IPractitionerGateway PractitionerGateway
        {
            get
            {
                if (this.practitionerGateway == null)
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
                if (this.patientGateway == null)
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
