using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Genders Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Condition { get; set; }
        public string Notes { get; set; }


        public ICollection<Consultation> Consultations { get; set; }

        public ICollection<Practitioner> Practitioners { get; set; }


    }

    public enum Genders
    {
        Male,
        Female,
    }
}