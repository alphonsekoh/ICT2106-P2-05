using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [DisplayName("Department Id")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
