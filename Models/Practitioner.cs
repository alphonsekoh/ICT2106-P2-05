using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Practitioner
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public string PractitionerDetails { get; set; }

    }
}
