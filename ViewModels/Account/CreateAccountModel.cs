using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.ViewModels
{
    public class CreateAccountModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password can't be less that 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Please enter your full name")]
        public string FullName { get; set; }
    }
}
