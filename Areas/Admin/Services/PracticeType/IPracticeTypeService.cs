using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPracticeTypeService
    {
        PracticeType GetPracticeType(int id);
        IEnumerable<PracticeType> GetAllPracticeTypes();
        void CreatePracticeType(PracticeType practiceType);
        void UpdatePracticeType(PracticeType practiceType);
        void DeletePracticeType(int id);
        void SavePracticeType();
    }
}
