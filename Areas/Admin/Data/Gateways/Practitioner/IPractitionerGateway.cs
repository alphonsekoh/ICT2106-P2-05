using PainAssessment.Areas.Admin.Models;
using System;
using System.Collections.Generic;

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
