using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Interfaces
{
    public interface ITemplateChecklistAdapter
    {
        void updateActive(int checklistID);
    }
}
