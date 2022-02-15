
using PainAssessment.Areas.Identity.Data;

namespace PainAssessment.Models
{
    public class Administrator
    {
        public string AccountId { get; set; }
        public AccountUser Account { get; set; }
        public string AdministratorDetails { get; set; }
    }
}
