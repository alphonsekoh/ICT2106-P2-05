using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Data.Gateways
{
    public interface IPractitionerGateway
    {
        void Add(Practitioner practitioner);
        Practitioner FindById(Guid id);
        IEnumerable<Practitioner> GetAll();
        void Update(Practitioner practitioner);
        void Delete(Guid id);
    }
}
