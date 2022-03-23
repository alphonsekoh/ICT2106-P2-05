using Microsoft.AspNetCore.Mvc;
using PainAssessment.Areas.Admin.Models.ModelBinder;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PainAssessment.Areas.Admin.Models
{
    [ModelBinder(typeof(ClinicalAreaModelBinder))]
    public class ClinicalArea
    {
        public int Id { get; private set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [DisplayName("Clinical Area")]
        public string Name { get; private set; }

        private readonly List<Practitioner> _practitioners = new();
        public virtual IReadOnlyList<Practitioner> Practitioners => _practitioners.ToList();

        public ClinicalArea(string name)
        {
            Name = name;
        }

        public ClinicalArea(string name, int clinicalAreaID)
        {
            Id = clinicalAreaID;
            Name = name;
        }

    }
}
