using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IPainEducationGateway
    {
        void Add(PainEducation painEducation);
        PainEducation FindById(int id);
        IEnumerable<PainEducation> GetAll();
        void Update(PainEducation painEducation);
        void Delete(int id);

    }
}
