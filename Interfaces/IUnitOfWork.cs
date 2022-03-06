using PainAssessment.Areas.Identity.Data;
using PainAssessment.Models;
using System;

namespace PainAssessment.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<AccountUser> AccountRepository { get; }
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Administrator> AdministratorRepository { get; }
        IGenericRepository<Practitioner> PractitionerRepository { get; }
        IGenericRepository<Patient> PatientRepository { get; }
        IGenericRepository<TemplateChecklist> TemplateChecklistRepository { get; }
        IGenericRepository<DefaultQuestion> DefaultQuestionRepository { get; }
        void Save();

    }
}
