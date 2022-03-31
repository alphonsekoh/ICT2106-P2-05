using System;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public interface IChecklistBuilder
    {
        public void buildChecklist();

        private void BuildCentral(Checklist checklist)
        {

        }

        private void BuildRegional(Checklist checklist)
        {

        }

        private void BuildLocal(Checklist checklist)
        {

        }

        public Checklist getChecklist();
    }
}
