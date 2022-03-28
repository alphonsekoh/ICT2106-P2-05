using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Services
{
    public class ChecklistService
    {
        private IUnitOfWork _unitOfWork;

        public Checklist GetById(int id)
        {
            return _unitOfWork.ChecklistRepo.GetById(id);
        }

        public List<Checklist> GetAll()
        {
            return _unitOfWork.ChecklistRepo.GetAll();
        }
        public List<Checklist> GetActiveChecklists()
        {
            return _unitOfWork.ChecklistRepo.GetActiveChecklists();
        }

        public List<Checklist> GetAllChecklistsFrom(int id)
        {
            return _unitOfWork.ChecklistRepo.GetAllChecklistsFrom(id);
        }



    }
}
