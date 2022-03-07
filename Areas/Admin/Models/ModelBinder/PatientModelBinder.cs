using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class PatientModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Form;
            var nameResult = data.TryGetValue("Name", out var name);
            var idResult = data.TryGetValue("PatientID", out var id);
            var genderResult = data.TryGetValue("Gender", out var gender);
            var birthDateResult = data.TryGetValue("BirthDate", out var birthDate);
            var conditionResult = data.TryGetValue("Condition", out var condition);
            var notesResult = data.TryGetValue("Notes", out var notes);

            if (nameResult)
            {
                var patient = new Patient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString());
                if (idResult)
                {
                    patient = new Patient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString(), Guid.Parse(id.ToString()));
                }
                bindingContext.Result = ModelBindingResult.Success(patient);

            }



            return Task.CompletedTask;


        }
    }
}
