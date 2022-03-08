using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Areas.Admin.Factory;
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
            var idResult = data.TryGetValue("Id", out var id);
            data.TryGetValue("Gender", out var gender);
            data.TryGetValue("BirthDate", out var birthDate);
            data.TryGetValue("Condition", out var condition);
            data.TryGetValue("Notes", out var notes);
            IPersonFactory personFactory = new PersonFactory();
            Person person;
            if (nameResult)
            {
                if (idResult)
                {
                    person = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString(), Guid.Parse(id.ToString()));
                } else
                {
                    person = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString());
                }
                bindingContext.Result = ModelBindingResult.Success(person);
            }
            return Task.CompletedTask;
        }
    }
}
