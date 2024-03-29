﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class RegionalDomain : Domain, IRegionalDomain
    {
        [Key]
        public int RowId { get; set; }

        [ForeignKey("Checklist")]//very important
        public int ChecklistId { get; set; }
        public virtual Checklist Checklist { get; private set; } //very important 

        //public string SubDomain { get; set; }
        //public string Determinant { get; set; }

        [NotMapped]
        public bool IsRegionalDeleted { get; set; } = false;

        public Boolean getIsRegionalDeleted()
        {
            return IsRegionalDeleted;
        }

    }
}
