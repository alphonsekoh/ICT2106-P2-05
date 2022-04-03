using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MvcChecklistContext _context;
        private MvcConsultationChecklistContext _Consultationcontext;

        private IChecklistRepo checklistRepo;
        private IConsultationChecklistRepo consultationChecklistRepo;

        public UnitOfWork(MvcChecklistContext context, MvcConsultationChecklistContext context2)
        {
            _context = context;
            _Consultationcontext = context2;
        }

        public IChecklistRepo ChecklistRepo
        {
            get
            {
                return checklistRepo = checklistRepo ?? new ChecklistRepo(_context);
            }
        }

        public IConsultationChecklistRepo ConsultationChecklistRepo
        {
            get
            {
                return consultationChecklistRepo = consultationChecklistRepo ?? new ConsultationChecklistRepo(_Consultationcontext);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void ConsultationSave()
        {
            _Consultationcontext.SaveChanges();
        }
    }
}
