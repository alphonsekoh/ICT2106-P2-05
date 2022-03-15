﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Areas.Admin.Models.Builder;
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
            Patient patient;

            Microsoft.AspNetCore.Http.IFormCollection data = bindingContext.HttpContext.Request.Form;
            bool nameResult = data.TryGetValue("Name", out Microsoft.Extensions.Primitives.StringValues name);
            bool idResult = data.TryGetValue("Id", out Microsoft.Extensions.Primitives.StringValues id);
            data.TryGetValue("Gender", out Microsoft.Extensions.Primitives.StringValues gender);
            data.TryGetValue("BirthDate", out Microsoft.Extensions.Primitives.StringValues birthDate);
            data.TryGetValue("Condition", out Microsoft.Extensions.Primitives.StringValues condition);
            data.TryGetValue("Notes", out Microsoft.Extensions.Primitives.StringValues notes);

            if (nameResult)
            {
                PatientBuilder patientBuilder = new PatientBuilder()
                                                .WithName(name.ToString())
                                                .WithGender(gender.ToString())
                                                .WithBirthDate(DateTime.Parse(birthDate.ToString()))
                                                .WithCondition(condition.ToString())
                                                .WithNotes(notes.ToString());
                if (idResult)
                {
                    patientBuilder.WithId(Guid.Parse(id.ToString()));
                }
                patient = patientBuilder.Build();
                bindingContext.Result = ModelBindingResult.Success(patient);
            }
            return Task.CompletedTask;
        }
    }
}
