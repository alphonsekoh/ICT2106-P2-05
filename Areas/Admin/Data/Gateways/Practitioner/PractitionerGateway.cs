using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Delete(int id)
        {
            Practitioner practitioner = context.Practitioners.Find(id);
            context.Practitioners.Remove(practitioner);
        }

        public Practitioner FindById(int id)
        {
            return context.Practitioners.Include(p => p.Department).Where(p => p.PractitionerID == id).FirstOrDefault();
        }

        public IEnumerable<Practitioner> GetAll()
        {
            //return context.Practitioners.ToList();
            return context.Practitioners.Include(p => p.Department).ToList();
        }

        public void Update(Practitioner practitioner)
        {
            context.Entry(practitioner).State = EntityState.Modified;
        }

    }
}
