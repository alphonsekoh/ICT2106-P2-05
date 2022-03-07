using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Areas.Admin.Util;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            patient.Name = Regex.Replace(patient.Name, @"\b\w{3,}\b", match => Utility.MaskName(match.Value));
            context.Patients.Add(patient);
        }

        public void Delete(Guid id)
        {
            Patient patient = context.Patients.Find(id);
            context.Patients.Remove(patient);
        }

        public Patient FindById(Guid id)
        {
            return context.Patients.Include(p => p.PractitionerPatients).ThenInclude(p => p.Practitioner).Where(p => p.PatientID == id).FirstOrDefault();
        }

        public IEnumerable<Patient> GetAll()
        {
            return context.Patients.Include(p => p.PractitionerPatients).ThenInclude(p => p.Practitioner).ToList();
        }

        public void Update(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
        }



    }
}
