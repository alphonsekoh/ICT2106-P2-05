using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public int patientID { get; set; }

    }
}