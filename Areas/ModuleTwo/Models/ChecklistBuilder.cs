using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class ChecklistBuilder : IChecklistBuilder
    {
        Checklist checklist = new Checklist();
        public void buildChecklist()
        {
            checklist.Overriden = false;
            checklist.NewCentralWeight = 0;
            checklist.NewRegionalWeight = 0;
            checklist.NewLocalWeight = 0;
            checklist.Active = true;

            BuildCentral(checklist);
            BuildRegional(checklist);
            BuildLocal(checklist);
        }

        private void BuildCentral(Checklist checklist)
        {
            checklist.Central = new List<CentralDomain>();
            checklist.Central.Add(new CentralDomain() { RowId = 1 });
        }

        private void BuildRegional(Checklist checklist)
        {
            checklist.Regional = new List<RegionalDomain>();
            checklist.Regional.Add(new RegionalDomain() { RowId = 1 });
        }

        private void BuildLocal(Checklist checklist)
        {
            checklist.Local = new List<LocalDomain>();
            checklist.Local.Add(new LocalDomain() { RowId = 1 });
        }

        public Checklist getChecklist()
        {
            return checklist;
        }
    }
}
