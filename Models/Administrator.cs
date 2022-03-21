using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Administrator
    {
        [Key]
        public Guid AdminId { get; set; }
        [Required]
        public Account Account { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int Experience { get; set; }
    }
}
