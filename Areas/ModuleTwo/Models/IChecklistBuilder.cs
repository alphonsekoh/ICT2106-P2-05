using System;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public interface IChecklistBuilder
    {
        public void buildChecklist();

        public Checklist getChecklist();
    }
}
