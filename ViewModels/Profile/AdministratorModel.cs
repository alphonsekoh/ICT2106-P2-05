using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.ViewModels.Profile
{
    public class AdministratorModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int Department { get; set; }
        public Guid AccountID { get; set; }
    }
}
