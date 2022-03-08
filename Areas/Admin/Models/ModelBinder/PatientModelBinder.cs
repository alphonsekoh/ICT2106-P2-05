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

            var data = bindingContext.HttpContext.Request.Form;
            var nameResult = data.TryGetValue("Name", out var name);
            var idResult = data.TryGetValue("Id", out var id);
            data.TryGetValue("Gender", out var gender);
            data.TryGetValue("BirthDate", out var birthDate);
            data.TryGetValue("Condition", out var condition);
            data.TryGetValue("Notes", out var notes);

            if (nameResult)
            {
                if (idResult)
                {
                    patient = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString(), Guid.Parse(id.ToString()));
                } else
                {
                    patient = personFactory.CreatePatient(name.ToString(), gender.ToString(), DateTime.Parse(birthDate.ToString()), condition.ToString(), notes.ToString());
                }
                bindingContext.Result = ModelBindingResult.Success(patient);
            }
            return Task.CompletedTask;
        }
    }
}
