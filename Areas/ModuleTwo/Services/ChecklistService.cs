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
        public IUnitOfWork _unitOfWork;
        private MvcChecklistContext _context;
        private MvcConsultationChecklistContext _Consultationcontext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork = _unitOfWork ?? new UnitOfWork(_context, _Consultationcontext);
            }
        }

        public ChecklistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Checklist GetById(int id)
        {
            return _unitOfWork.ChecklistRepo.GetById(id);
        }

        public List<Checklist> GetAll(int user)
        {
            return _unitOfWork.ChecklistRepo.GetAll(user);
        }
        public List<Checklist> GetActiveChecklists()
        {
            return _unitOfWork.ChecklistRepo.GetActiveChecklists();
        }

        public List<Checklist> GetAllChecklistsFrom(int id)
        {
            return _unitOfWork.ChecklistRepo.GetAllChecklistsFrom(id);
        }

        public void Delete(Checklist checklist)
        {
           _unitOfWork.ChecklistRepo.Delete(checklist);
           _unitOfWork.Save();
        }

        public Checklist InitialiseChecklist()
        {
            return _unitOfWork.ChecklistRepo.InsertGet();
            //_unitOfWork.Save();
        }

        public Checklist InitialiseConsultChecklist()
        {
            return _unitOfWork.ChecklistRepo.InsertGetTest();
        }

        public void Insert(Checklist checklist)
        {
            _unitOfWork.ChecklistRepo.InsertPost(checklist);
            _unitOfWork.Save();
        }

        public void Update(Checklist checklist)
        {
            _unitOfWork.ChecklistRepo.PreUpdate(checklist);
            _unitOfWork.Save();
            _unitOfWork.ChecklistRepo.Update(checklist);
            _unitOfWork.Save();
        }

        public Checklist GetBySessionId(int id)
        {
            return _unitOfWork.ConsultationChecklistRepo.GetBySessionId(id);
        }

        public void InsertConsultationChecklist(Checklist checklist)
        {
            _unitOfWork.ConsultationChecklistRepo.InsertConsultationChecklist(checklist);
            _unitOfWork.ConsultationSave();
        }
        public Boolean ChecklistExists(int id)
        {
            return _unitOfWork.ChecklistRepo.CheckExists(id);
        }


    }
}
