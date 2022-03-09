using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public class PractitionerGateway : IPractitionerGateway
    {
        internal HospitalContext context;

        public PractitionerGateway(HospitalContext context)
        {
            this.context = context;
        }

        public void Add(Practitioner practitioner)
        {
            context.Practitioners.Add(practitioner);
        }

        public void Delete(Guid id)
        {
            Practitioner practitioner = context.Practitioners.Find(id);
            context.Practitioners.Remove(practitioner);
        }

        public Practitioner FindById(Guid id)
        {
            return context.Practitioners.Include(p => p.ClinicalArea).Include(p => p.PracticeType).Include(p => p.PractitionerPatients).ThenInclude(p => p.Patient).Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Practitioner> GetAll()
        {
            //return context.Practitioners.ToList();
            return context.Practitioners.Include(p => p.ClinicalArea).Include(p => p.PracticeType).Include(p => p.PractitionerPatients).ThenInclude(p => p.Patient).ToList();
        }

        public void Update(Practitioner practitioner)
        {
            context.Entry(practitioner).State = EntityState.Modified;
        }

    }
}
