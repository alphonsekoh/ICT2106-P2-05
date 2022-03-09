using System.ComponentModel.DataAnnotations;

namespace PainAssessment.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your username")]
        public int accountId { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool Test { get; set; }
    }
}
