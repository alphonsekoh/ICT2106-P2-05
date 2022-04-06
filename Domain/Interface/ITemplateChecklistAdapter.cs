using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Interfaces
{
    public interface ITemplateChecklistAdapter
    {
        void updateActive(int checklistID);

        void editTemplate(int checklistID, string name, string description, bool active);

        /// Domain has been simplified to 
        /// 0 - Central
        /// 1 - Regional
        /// 2 - Local
        void addQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage);
        int getRecentlyModifiedChecklist();

        void updateQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage, int rowId);
        void deleteQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage, int rowId);
    }
}
