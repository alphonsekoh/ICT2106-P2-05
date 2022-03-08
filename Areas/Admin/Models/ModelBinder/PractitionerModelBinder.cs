using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Areas.Admin.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class PractitionerModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Form;
            var nameResult = data.TryGetValue("Name", out var name);
            var idResult = data.TryGetValue("Id", out var id);
            data.TryGetValue("Experience", out var experience);
            data.TryGetValue("PracticeType", out var practiceType);
            data.TryGetValue("PriorPainEducation", out var priorPainEducation);
            data.TryGetValue("ClinicalAreaID", out var clinicalAreaID);

            IPersonFactory personFactory = new PersonFactory();

            if (nameResult)
            {
                var practitioner = personFactory.CreatePractitioner(name.ToString(), experience.ToString(), practiceType.ToString(), priorPainEducation.ToString(), Int32.Parse(clinicalAreaID));
                if (idResult)
                {
                    practitioner = personFactory.CreatePractitioner(name.ToString(), experience.ToString(), practiceType.ToString(), priorPainEducation.ToString(), Int32.Parse(clinicalAreaID), Guid.Parse(id.ToString()));
                }
                bindingContext.Result = ModelBindingResult.Success(practitioner);
            }

            return Task.CompletedTask;
        }
    }
}
