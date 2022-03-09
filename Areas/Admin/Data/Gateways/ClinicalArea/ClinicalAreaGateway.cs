using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.Admin.Models;
using PainAssessment.Data;
using System.Collections.Generic;
using System.Linq;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public class ClinicalAreaGateway : IClinicalAreaGateway
    {
        internal HospitalContext context;

        public ClinicalAreaGateway(HospitalContext context)
        {
            this.context = context;
        }
        public void Add(ClinicalArea clinicalArea)
        {
            context.ClinicalAreas.Add(clinicalArea);
        }

        public void Delete(int id)
        {
            ClinicalArea clinicalArea = context.ClinicalAreas.Find(id);
            context.ClinicalAreas.Remove(clinicalArea);
        }

        public ClinicalArea FindById(int id)
        {
            return context.ClinicalAreas.Include(d => d.Practitioners).Where(d => d.Id == id).FirstOrDefault();

        }
        public IEnumerable<ClinicalArea> GetAll()
        {
            return context.ClinicalAreas.Include(d => d.Practitioners).ToList();
        }

        public void Update(ClinicalArea clinicalArea)
        {
            context.Entry(clinicalArea).State = EntityState.Modified;
        }
    }
}
