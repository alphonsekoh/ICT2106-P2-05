using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AccountStatus { get; set; }
    }
}
