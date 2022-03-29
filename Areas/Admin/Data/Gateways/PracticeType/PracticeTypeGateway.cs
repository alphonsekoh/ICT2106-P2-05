using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public class PracticeTypeGateway : IPracticeTypeGateway
    {
        internal HospitalContext context;

        public PracticeTypeGateway(HospitalContext context)
        {
            this.context = context;
        }
        public void Add(PracticeType practiceType)
        {
            context.PracticeTypes.Add(practiceType);
        }

        public void Delete(int id)
        {
            PracticeType practiceType = context.PracticeTypes.Find(id);
            context.PracticeTypes.Remove(practiceType);
        }

        public PracticeType FindById(int id)
        {
            return context.PracticeTypes.Include(d => d.Practitioners).Where(d => d.Id == id).FirstOrDefault();

        }

        public IEnumerable<PracticeType> GetAll()
        {
            return context.PracticeTypes.Include(d => d.Practitioners).ToList();
        }

        public void Update(PracticeType practiceType)
        {
            context.Entry(practiceType).State = EntityState.Modified;
        }
    }
}
