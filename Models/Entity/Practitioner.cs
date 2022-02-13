using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PainAssessment.Models
{
    public class Practitioner : Person
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DisplayName("Department Id")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        // public ICollection<TemplateChecklist> TemplateChecklists { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public ICollection<Consultation> Consultations { get; set; }
    }
}