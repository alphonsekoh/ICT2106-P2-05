using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<Practitioner> Practitioners { get; set; }
    }
}
