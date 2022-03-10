using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public class PainEducationGateway : IPainEducationGateway
    {
        internal HospitalContext context;

        public PainEducationGateway(HospitalContext context)
        {
            this.context = context;
        }
        public void Add(PainEducation painEducation)
        {
            context.PainEducations.Add(painEducation);
        }

        public void Delete(int id)
        {
            PainEducation painEducation = context.PainEducations.Find(id);
            context.PainEducations.Remove(painEducation);
        }

        public PainEducation FindById(int id)
        {
            return context.PainEducations.Where(d => d.Id == id).FirstOrDefault();

        }

        public IEnumerable<PainEducation> GetAll()
        {
            return context.PainEducations.ToList();
        }

        public void Update(PainEducation painEducation)
        {
            context.Entry(painEducation).State = EntityState.Modified;
        }
    }
}
