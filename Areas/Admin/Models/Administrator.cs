using PainAssessment.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.Admin.Models
{
    public class Administrator
    {
        [Key]
        public Guid AdminId { get; set; }
        [Required]
        public Account Account { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int ClinicalAreaID { get; set; }
        public int Experience { get; set; }
    }
}
