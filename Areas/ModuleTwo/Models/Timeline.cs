using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Timeline
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Session No")]
        public int SessionNo { get; set; }
        [Display(Name = "Last Visit")]
        [DataType(DataType.Date)]
        public DateTime LastVisit { get; set; }
        [Display(Name = "Clinical Area")]
        public string ClinicalArea { get; set; }
        [Display(Name = "Central Modulation")]
        public int CentralModulation { get; set; }
        [Display(Name = "RegionalInfluence")]
        public int RegionalInfluence { get; set; }
        [Display(Name = "Local Stimulation")]
        public int LocalStimulation { get; set; }

    }
}