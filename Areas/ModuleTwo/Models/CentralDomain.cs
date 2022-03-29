using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class CentralDomain : Domain, ICentralDomain
    {
        [Key]
        public int RowId { get; set; }

        [ForeignKey("Checklist")]//very important
        public int ChecklistId { get; set; }
        public virtual Checklist Checklist { get; private set; } //very important 


        [NotMapped]
        public bool IsCentralDeleted { get; set; } = false;

        public Boolean getIsCentralDeleted()
        {
            return IsCentralDeleted;
        }

    }
}
