using PainAssessment.Areas.Identity.Data;
using PainAssessment.Models;
using System;

namespace PainAssessment.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AccountUser> AccountRepository { get; }
        IGenericRepository<Patient> PatientRepository { get; }
        IGenericRepository<TemplateChecklist> TemplateChecklistRepository { get; }
        void Save();

    }
}
