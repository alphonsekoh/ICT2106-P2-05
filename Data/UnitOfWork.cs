using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalContext _context;

        private IGenericRepository<Account> accountRepository;
        private IGenericRepository<Administrator> adminRepository;

        private IGenericRepository<TemplateChecklist> templateChecklistRepository;
        private IGenericRepository<DefaultQuestion> defaultQuestionRepository;
        private IGenericRepository<User> userRepository;

        public UnitOfWork(HospitalContext context)
        {
            this._context = context;
        }

        public IGenericRepository<Account> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(_context);
                }
                return accountRepository;
            }

        }

        public IGenericRepository<Administrator> AdministratorRepository
        {
            get
            {
                if (this.adminRepository == null)
                {
                    this.adminRepository = new GenericRepository<Administrator>(_context);
                }
                return adminRepository;
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
                if (this.defaultQuestionRepository == null)
                {
                    this.defaultQuestionRepository = new GenericRepository<DefaultQuestion>(_context);
                }
                return defaultQuestionRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
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
