using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public interface IChecklistRepo
    {
        List<Checklist> GetAll();
        Checklist GetById(int id);
        Checklist InsertGet();

        void InsertPost(Checklist checklist);

        void PreUpdate(Checklist checklist);

        void Update(Checklist checklist);

        void Delete(Checklist checklist);

        Boolean CheckExists(int id);
    }
}
