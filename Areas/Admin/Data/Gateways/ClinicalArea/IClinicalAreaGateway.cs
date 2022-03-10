using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IClinicalAreaGateway
    {
        void Add(ClinicalArea clinicalArea);
        ClinicalArea FindById(int id);
        IEnumerable<ClinicalArea> GetAll();
        void Update(ClinicalArea clinicalArea);
        void Delete(int id);

    }
}
