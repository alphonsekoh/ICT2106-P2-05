//using PainAssessment.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using PainAssessment.Areas.Admin.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PainAssessment.Areas.Identity.Data
{
    public class AccountUser : IdentityUser
    {

        private string FirstName { get; set; }
        private string LastName { get; set; }

        [Required]
        private string Role { get; set; }

        //[Required]
        //[DisplayName("Department Id")]
        //public int DepartmentId { get; set; }

        //public Department Department { get; set; }
    }
}
