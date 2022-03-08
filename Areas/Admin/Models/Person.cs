using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.Admin.Models
{
    public abstract class Person
    {
        public Guid Id { get; protected set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; protected set; }

    }
}
