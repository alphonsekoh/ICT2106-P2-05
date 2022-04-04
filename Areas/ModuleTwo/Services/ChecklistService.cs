using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Services
{
    public class ChecklistService : IChecklistService
    {
        public IChecklistUnitOfWork _ChecklistUnitOfWork;
        private MvcChecklistContext _context;
        private MvcConsultationChecklistContext _Consultationcontext;

        public IChecklistUnitOfWork ChecklistUnitOfWork
        {
            get
            {
                return _ChecklistUnitOfWork = _ChecklistUnitOfWork ?? new ChecklistUnitOfWork(_context, _Consultationcontext);
            }
        }

        public ChecklistService(IChecklistUnitOfWork ChecklistUnitOfWork)
        {
            _ChecklistUnitOfWork = ChecklistUnitOfWork;
        }
        public Checklist GetById(int id)
        {
            return _ChecklistUnitOfWork.ChecklistRepo.GetById(id);
        }

        public List<Checklist> GetAll(int user)
        {
            return _ChecklistUnitOfWork.ChecklistRepo.GetAll(user);
        }
        public List<Checklist> GetActiveChecklists()
        {
            return _ChecklistUnitOfWork.ChecklistRepo.GetActiveChecklists();
        }

        public List<Checklist> GetAllChecklistsFrom(int id)
        {
            return _ChecklistUnitOfWork.ChecklistRepo.GetAllChecklistsFrom(id);
        }

        public void Delete(Checklist checklist)
        {
           _ChecklistUnitOfWork.ChecklistRepo.Delete(checklist);
           _ChecklistUnitOfWork.Save();
        }

        public Checklist InitialiseChecklist()
        {
            return _ChecklistUnitOfWork.ChecklistRepo.InsertGet();
            //_ChecklistUnitOfWork.Save();
        }

        public Checklist InitialiseConsultChecklist()
        {
            return _ChecklistUnitOfWork.ChecklistRepo.InsertGetTest();
        }

        public void Insert(Checklist checklist)
        {
            _ChecklistUnitOfWork.ChecklistRepo.InsertPost(checklist);
            _ChecklistUnitOfWork.Save();
        }

        public void Update(Checklist checklist)
        {
            _ChecklistUnitOfWork.ChecklistRepo.PreUpdate(checklist);
            _ChecklistUnitOfWork.Save();
            _ChecklistUnitOfWork.ChecklistRepo.Update(checklist);
            _ChecklistUnitOfWork.Save();
        }

        public Checklist GetBySessionId(int id)
        {
            return _ChecklistUnitOfWork.ConsultationChecklistRepo.GetBySessionId(id);
        }

        public void InsertConsultationChecklist(Checklist checklist)
        {
            _ChecklistUnitOfWork.ConsultationChecklistRepo.InsertConsultationChecklist(checklist);
            _ChecklistUnitOfWork.ConsultationSave();
        }
        public Boolean ChecklistExists(int id)
        {
            return _ChecklistUnitOfWork.ChecklistRepo.CheckExists(id);
        }


    }
}
