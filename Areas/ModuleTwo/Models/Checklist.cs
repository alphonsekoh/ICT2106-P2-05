using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public int checklistID { get; set; }
        public string checklistName { get; set; }
        public string checklistDescription { get; set; }
    }
}
