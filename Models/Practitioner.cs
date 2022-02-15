
using PainAssessment.Areas.Identity.Data;

namespace PainAssessment.Models
{
    public class Practitioner
    {
        public string AccountId { get; set; }
        public AccountUser Account { get; set; }
        public string PractitionerDetails { get; set; }
    }
}
