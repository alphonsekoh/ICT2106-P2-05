using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class Practitioner
    {
        public Guid PractitionerID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Role { get; set; }
        public int ClinicalAreaID { get; set; }
        public ClinicalArea ClinicalArea { get; set; }

    }
}
