using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class ClinicalAreaModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Form;
            var nameResult = data.TryGetValue("Name", out var name);
            var idResult = data.TryGetValue("ClinicalAreaID", out var id);

            if (nameResult)
            {
                var clinicalArea = new ClinicalArea(name.ToString());
                if (idResult)
                {
                    clinicalArea = new ClinicalArea(name.ToString(), Int32.Parse(id.ToString()));
                }
                bindingContext.Result = ModelBindingResult.Success(clinicalArea);

            }



            return Task.CompletedTask;
        }
        }
    }

