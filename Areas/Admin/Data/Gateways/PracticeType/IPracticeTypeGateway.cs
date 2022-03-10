using PainAssessment.Areas.Admin.Models;
using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IPracticeTypeGateway
    {
        void Add(PracticeType practiceType);
        PracticeType FindById(int id);
        IEnumerable<PracticeType> GetAll();
        void Update(PracticeType practiceType);
        void Delete(int id);

    }
}
