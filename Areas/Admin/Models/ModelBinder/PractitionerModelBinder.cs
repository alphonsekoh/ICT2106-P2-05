using Microsoft.AspNetCore.Mvc.ModelBinding;
using PainAssessment.Areas.Admin.Models.Builder;
using PainAssessment.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Models.ModelBinder
{
    public class PractitionerModelBinder : IModelBinder
    {
        private readonly IClinicalAreaService clinicalAreaService;
        private readonly IPracticeTypeService practiceTypeService;
        private readonly IPainEducationService painEducationService;
        public PractitionerModelBinder(IClinicalAreaService clinicalAreaService, IPracticeTypeService practiceTypeService, IPainEducationService painEducationService)
        {
            this.clinicalAreaService = clinicalAreaService;
            this.practiceTypeService = practiceTypeService;
            this.painEducationService = painEducationService;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Practitioner practitioner;

            Microsoft.AspNetCore.Http.IFormCollection data = bindingContext.HttpContext.Request.Form;
            bool nameResult = data.TryGetValue("Name", out Microsoft.Extensions.Primitives.StringValues name);
            bool idResult = data.TryGetValue("Id", out Microsoft.Extensions.Primitives.StringValues id);
            bool experienceResult = data.TryGetValue("Experience", out Microsoft.Extensions.Primitives.StringValues experience);
            bool selectedResult = data.TryGetValue("SelectedPainEducation", out Microsoft.Extensions.Primitives.StringValues selectedPainEducation);
            bool clinicResult = data.TryGetValue("ClinicalAreaID", out Microsoft.Extensions.Primitives.StringValues clinicalAreaID);
            bool practiceResult = data.TryGetValue("PracticeTypeID", out Microsoft.Extensions.Primitives.StringValues practiceTypeID);

            bool parseClinicSuccess = int.TryParse(clinicalAreaID, out int parsedClinicID);
            bool parsePracticeSuccess = int.TryParse(practiceTypeID, out int parsedPracticeTypeID);


            if (!nameResult || !experienceResult || !selectedResult || !clinicResult || !practiceResult)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            else
            {
                int createdPracticeTypeID = default;
                int createdClinicID = default;
                List<int> priorEducationList = new();
                if (!parsePracticeSuccess)
                {
                    PracticeType newPracticeType = new(practiceTypeID);
                    practiceTypeService.CreatePracticeType(newPracticeType);
                    practiceTypeService.SavePracticeType();
                    createdPracticeTypeID = newPracticeType.Id;
                }
                if (!parseClinicSuccess)
                {
                    ClinicalArea newClinicalArea = new(clinicalAreaID);
                    clinicalAreaService.CreateClinicalArea(newClinicalArea);
                    clinicalAreaService.SaveClinicalArea();
                    createdClinicID = newClinicalArea.Id;
                }
                foreach (string prior in selectedPainEducation)
                {
                    bool parsePriorSuccess = int.TryParse(prior, out int parsedPainEducation);
                    if (parsePriorSuccess)
                    {
                        priorEducationList.Add(parsedPainEducation);
                    }
                    else
                    {
                        PainEducation newPainEducation = new(prior);
                        painEducationService.CreatePainEducation(newPainEducation);
                        painEducationService.SavePainEducation();
                        priorEducationList.Add(newPainEducation.Id);
                    }
                }
                IPractitionerBuilder practitionerBuilder = new PractitionerBuilder().WithName(name.ToString())
                                                                                   .WithExperience(experience.ToString())
                                                                                   .WithPainEducation(string.Join(",", priorEducationList))
                                                                                   .WithClinic(parseClinicSuccess ? parsedClinicID : createdClinicID)
                                                                                   .WithPracticeType(parsePracticeSuccess ? parsedPracticeTypeID : createdPracticeTypeID);


                if (idResult)
                {
                    practitionerBuilder.WithId(Guid.Parse(id.ToString()));
                }
                practitioner = practitionerBuilder.Build();
                practitioner.SelectedPainEducation = selectedPainEducation;
                bindingContext.Result = ModelBindingResult.Success(practitioner);

            }
            return Task.CompletedTask;
        }
    }
}
