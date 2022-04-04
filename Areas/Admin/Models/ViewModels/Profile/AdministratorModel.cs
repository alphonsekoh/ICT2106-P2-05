using System;

namespace PainAssessment.Areas.Admin.Models.ViewModels.Profile
{
    public class AdministratorModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int Experience { get; set; }
        public string ClinicalArea { get; set; }
        public Guid AccountID { get; set; }
    }
}
