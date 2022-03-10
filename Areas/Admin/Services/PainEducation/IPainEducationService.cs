using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IPainEducationService
    {
        PainEducation GetPainEducation(int id);
        IEnumerable<PainEducation> GetAllPainEducations();
        void CreatePainEducation(PainEducation painEducation);
        void UpdatePainEducation(PainEducation painEducation);
        void DeletePainEducation(int id);
        void SavePainEducation();
    }
}
