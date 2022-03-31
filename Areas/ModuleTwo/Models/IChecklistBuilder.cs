using System;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public interface IChecklistBuilder
    {
        public void buildChecklist();

        public void BuildCentral(Checklist checklist);

        public void BuildRegional(Checklist checklist);

        public void BuildLocal(Checklist checklist);

        public Checklist getChecklist();
    }
}
