using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Services
{
    public interface IChecklistService
    {
        public IChecklistUnitOfWork ChecklistUnitOfWork { get; }
        public Checklist GetById(int id);
        public List<Checklist> GetAll(int user);
        public List<Checklist> GetActiveChecklists();
        public List<Checklist> GetAllChecklistsFrom(int id);
        public Checklist InitialiseChecklist();
        public Checklist InitialiseConsultChecklist();
        public void Delete(Checklist checklist);
        public void Insert(Checklist checklist);
        public void Update(Checklist checklist);
        public Checklist GetBySessionId(int id);
        public void InsertConsultationChecklist(Checklist checklist);
        public Boolean ChecklistExists(int id);

    }
}
