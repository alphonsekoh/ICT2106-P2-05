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
        public string Password { get; set; }
        public string AccountStatus { get; set; }
        public string Role { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool FirstSignIn { get; set; }

    }
}
