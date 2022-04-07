using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Interfaces
{
    public interface ITemplateChecklistAdapter
    {
        void UpdateActive(int checklistID);

        void EditTemplate(int checklistID, string name, string description, bool active);

        /// Domain has been simplified to 
        /// 0 - Central
        /// 1 - Regional
        /// 2 - Local
        void AddQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage);
        int GetRecentlyModifiedChecklist();

        void UpdateQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage, int rowId);
        void DeleteQuestion(int checklistID, string subDomain, string determinant, int domain, int maxWeightage, int rowId);
    }
}
