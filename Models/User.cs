using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class User
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string UserDetails { get; set; }
        [Required]
        public string Role { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

    }
}
