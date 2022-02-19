using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Checklist
    {
        [Key]
        public int Id { get; set; }
        public int checklistID { get; set; }
        public string checklistName { get; set; }
        public string checklistDescription { get; set; }

        public virtual List<CentralDomain> Central { get; set; } = new List<CentralDomain>();//detail very important
        public virtual List<RegionalDomain> Regional { get; set; } = new List<RegionalDomain>();//detail very important
        public virtual List<LocalDomain> Local { get; set; } = new List<LocalDomain>();//detail very important

    }
}
