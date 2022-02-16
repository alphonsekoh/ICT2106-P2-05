using PainAssessment.Interfaces;
using PainAssessment.Models;

namespace PainAssessment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalContext _context;
        private IGenericRepository<Account> accountRepository;
        private IGenericRepository<Administrator> administratorRepository;
        private IGenericRepository<Patient> patientRepository;
        private IGenericRepository<Department> departmentRepository;
        private IGenericRepository<Practitioner> practitionerRepository;
        private IGenericRepository<TemplateChecklist> templateChecklistRepository;
        private IGenericRepository<DefaultQuestion> defaultQuestionRepository;

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
                if (this.administratorRepository == null)
                {
                    this.administratorRepository = new GenericRepository<Administrator>(_context);
                }
                return administratorRepository;
            }

        }

        public IGenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(_context);
                }
                return departmentRepository;
            }
        }

        public IGenericRepository<Practitioner> PractitionerRepository
        {
            get
            {
                if (this.practitionerRepository == null)
                {
                    this.practitionerRepository = new GenericRepository<Practitioner>(_context);
                }
                return practitionerRepository;
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
