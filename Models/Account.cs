using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string AccountStatus { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
