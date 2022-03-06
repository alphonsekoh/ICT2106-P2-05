using PainAssessment.Areas.Identity.Data;
using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalContext _context;
        private IGenericRepository<AccountUser> accountRepository;

        private IGenericRepository<Patient> patientRepository;

        private IGenericRepository<TemplateChecklist> templateChecklistRepository;
        private IGenericRepository<DefaultQuestion> defaultQuestionRepository;

        public UnitOfWork(HospitalContext context)
        {
            this._context = context;
        }

        public IGenericRepository<AccountUser> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<AccountUser>(_context);
                }
                return accountRepository;
            }

        }



        public IGenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this.patientRepository == null)
                {
                    this.patientRepository = new GenericRepository<Patient>(_context);
                }
                return patientRepository;
            }
        }

        public IGenericRepository<TemplateChecklist> TemplateChecklistRepository
        {
            get
            {
                if (this.templateChecklistRepository == null)
                {
                    this.templateChecklistRepository = new GenericRepository<TemplateChecklist>(_context);
                }
                return templateChecklistRepository;
            }
        }

        public IGenericRepository<DefaultQuestion> DefaultQuestionRepository
        {
            get
            {
                if(this.defaultQuestionRepository == null)
                {
                    this.defaultQuestionRepository = new GenericRepository<DefaultQuestion>(_context);
                }
                return defaultQuestionRepository;
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
