using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class Practitioner
    {
        public int PractitionerID { get; set; }
        [Required]
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
