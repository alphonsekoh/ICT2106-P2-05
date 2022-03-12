using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Patient
    {
        [Display(Name = "Patient ID")]
        public int Id { get; set; }

        [Display(Name = "Patient Name")]
        public string patientName { get; set; }

        [Display(Name = "Patient Age")]
        public int patientAge { get; set; }

        [Display(Name = "Condition")]
        public string condition { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Sessions")]
        public int sessions { get; set; }

        [Display(Name = "Patient Notes")]
        public string patientNotes { get; set; }

        [Display(Name = "Last Visit")]
        public DateTime? lastVisit { get; set; }
    }
}
