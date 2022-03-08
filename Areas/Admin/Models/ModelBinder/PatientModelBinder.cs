using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Areas.Admin.Models.Factory;
using System;
using System.Threading.Tasks;


namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class PatientModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            IPersonFactory personFactory = new PersonFactory();
            IPatient patient;

            Microsoft.AspNetCore.Http.IFormCollection data = bindingContext.HttpContext.Request.Form;
            bool nameResult = data.TryGetValue("Name", out Microsoft.Extensions.Primitives.StringValues name);
            bool idResult = data.TryGetValue("Id", out Microsoft.Extensions.Primitives.StringValues id);
            data.TryGetValue("Gender", out Microsoft.Extensions.Primitives.StringValues gender);
            data.TryGetValue("BirthDate", out Microsoft.Extensions.Primitives.StringValues birthDate);
            data.TryGetValue("Condition", out Microsoft.Extensions.Primitives.StringValues condition);
            data.TryGetValue("Notes", out Microsoft.Extensions.Primitives.StringValues notes);

            if (nameResult)
            {
                if (idResult)
                {
                    patient = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString(), Guid.Parse(id.ToString()));
                }
                else
                {
                    patient = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString());
                }
                bindingContext.Result = ModelBindingResult.Success(patient);
            }
            return Task.CompletedTask;
        }
    }
}
