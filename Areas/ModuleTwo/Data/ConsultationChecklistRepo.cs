using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class ConsultationChecklistRepo : IConsultationChecklistRepo
    {
        private MvcConsultationChecklistContext _Consultationcontext;

        public ConsultationChecklistRepo(MvcConsultationChecklistContext context)
        {
            _Consultationcontext = context;
        }

        public Checklist GetBySessionId(int id)
        {
            Checklist checklist = _Consultationcontext.ConsultationChecklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.SessionId == id).FirstOrDefault();
            return checklist;
        }

        public void InsertConsultationChecklist(Checklist checklist)
        {
            _Consultationcontext.Add(checklist);
        }
    }
}
