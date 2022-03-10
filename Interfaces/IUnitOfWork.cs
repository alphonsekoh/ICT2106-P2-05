using PainAssessment.Models;
using System;

namespace PainAssessment.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Administrator> AdministratorRepository { get; }
        IGenericRepository<TemplateChecklist> TemplateChecklistRepository { get; }
        IGenericRepository<DefaultQuestion> DefaultQuestionRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        void Save();

    }
}
