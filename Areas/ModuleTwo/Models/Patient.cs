using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string condition { get; set; }
        public string gender { get; set; }
        public int consultationID { get; set; }
    }
}
