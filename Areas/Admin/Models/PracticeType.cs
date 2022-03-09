using Microsoft.AspNetCore.Mvc;
using PainAssessment.Areas.Admin.Models.ModelBinder;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PainAssessment.Areas.Admin.Models
{
    [ModelBinder(typeof(PracticeTypeModelBinder))]
    public class PracticeType
    {
        public int Id { get; private set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [DisplayName("Practice Type")]
        public string Name { get; private set; }


        private readonly List<Practitioner> _practitioners = new();
        public virtual IReadOnlyList<Practitioner> Practitioners => _practitioners.ToList();

        public PracticeType(string name)
        {
            Name = name;
        }

        public PracticeType(string name, int id)
        {
            Id = id;
            Name = name;
        }

    }
}
