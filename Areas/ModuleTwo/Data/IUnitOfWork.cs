using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public interface IUnitOfWork
    {
        IChecklistRepo ChecklistRepo { get; }
        IConsultationChecklistRepo ConsultationChecklistRepo { get; }

        void Save();

        void ConsultationSave();
    }
}
