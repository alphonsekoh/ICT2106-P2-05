using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data.Gateways
{ 
    public class PatientGateway : IPatientGateway
    {
        internal HospitalContext context;

        public PatientGateway(HospitalContext context)
        {
            this.context = context;
        }

        public void Add(Patient patient)
        {
            context.Patients.Add(patient);
        }

        public void Delete(Guid id)
        {
            Patient patient = context.Patients.Find(id);
            context.Patients.Remove(patient);
        }

        public Patient FindById(Guid id)
        {
            return context.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return context.Patients.ToList();
        }

        public void Update(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
        }
    }
}
