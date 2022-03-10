using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class PainEducationModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Microsoft.AspNetCore.Http.IFormCollection data = bindingContext.HttpContext.Request.Form;
            bool nameResult = data.TryGetValue("Name", out Microsoft.Extensions.Primitives.StringValues name);
            bool idResult = data.TryGetValue("Id", out Microsoft.Extensions.Primitives.StringValues id);

            if (nameResult)
            {
                PainEducation painEducation = new(name.ToString());
                if (idResult)
                {
                    painEducation = new PainEducation(name.ToString(), Int32.Parse(id.ToString()));
                }
                bindingContext.Result = ModelBindingResult.Success(painEducation);

            }

            return Task.CompletedTask;
        }
    }
}

