using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Interfaces;
using PainAssessment.Areas.ModuleTwo.Models;
using PainAssessment.Models;
using System.Collections.Generic;

namespace PainAssessment.Domain
{
    public class TemplateChecklistAdapter: ITemplateChecklistAdapter
    {
        private readonly Areas.ModuleTwo.Services.IChecklistService checklistser;

        public TemplateChecklistAdapter(Areas.ModuleTwo.Services.IChecklistService checklistservice)
        {
            checklistser = checklistservice;
        }
        public void updateActive(int checklistID)
        {
         
            Checklist checklist = checklistser.GetById(checklistID);
                if (checklist.Active)
                {
                    checklist.Active = false;
                }
                else
                {
                    checklist.Active = true;
                }

            checklistser.Update(checklist);
        }
    }
}
