using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MvcChecklistContext _context;
        private IChecklistRepo checklistRepo;

        public UnitOfWork(MvcChecklistContext context)
        {
            _context = context;
        }

        public IChecklistRepo ChecklistRepo
        {
            get
            {
                return checklistRepo = checklistRepo ?? new ChecklistRepo(_context);
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
