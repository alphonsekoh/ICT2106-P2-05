using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Services
{
    public interface IClinicalAreaService
    {
        ClinicalArea GetClinicalArea(int id);
        IEnumerable<ClinicalArea> GetAllClinicalAreas();
        void CreateClinicalArea(ClinicalArea clinicalArea);
        void UpdateClinicalArea(ClinicalArea clinicalArea);
        void DeleteClinicalArea(int id);
        void SaveClinicalArea();
    }
}
