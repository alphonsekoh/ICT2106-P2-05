using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models
{
    public class ClinicalArea
    {
        public int ClinicalAreaID { get; private set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [DisplayName("Clinical Area")]
        public string Name { get; private set; }
        public ICollection<Practitioner> Practitioners { get; private set; }

        public ClinicalArea( string name )
        {
            Name = name;
        }

        public ClinicalArea( string name,int clinicalAreaID)
        {
            ClinicalAreaID = clinicalAreaID;
            Name = name;
        }
    }
}
