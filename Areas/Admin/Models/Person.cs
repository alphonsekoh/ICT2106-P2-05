using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        //public string Username { get; set; }
        //[Required]
        //public string Password { get; set; }

    }
}