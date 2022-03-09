using Microsoft.AspNetCore.Mvc;
using PainAssessment.Areas.Admin.Models.ModelBinder;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.Admin.Models
{
    [ModelBinder(typeof(PainEducationModelBinder))]
    public class PainEducation
    {
        public int Id { get; private set; }
        [Required]
        [DisplayName("Prior Pain Education")]
        public string Name { get; private set; }
        public PainEducation(string name)
        {
            Name = name;
        }

        public PainEducation(string name, int clinicalAreaID)
        {
            Id = clinicalAreaID;
            Name = name;
        }
    }
}
