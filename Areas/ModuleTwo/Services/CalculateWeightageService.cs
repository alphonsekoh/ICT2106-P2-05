using PainAssessment.Areas.ModuleTwo.Models.CalculateWeightageModels;
using PainAssessment.Areas.ModuleTwo.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PainAssessment.Areas.ModuleTwo.Services
{
    public class CalculateWeightageService : ICalculateWeightageService
    {
        public ReadOnlyDictionary<string, double> calcWeightageFromThreeInputs(double localInput, double centralInput, double regionalInput)
        {
            return new WeightageObjectFromThreeDoubles(localInput, centralInput, regionalInput).getThreeWeightagesAsStrDoubleDict();
        }

        public ReadOnlyDictionary<string, double> calcWeightageFromThreeInputs(string localInput, string centralInput, string regionalInput)
        {
            return new WeightageObjectFromThreeStrings(localInput, centralInput, regionalInput).getThreeWeightagesAsStrDoubleDict();
        }
    }
}
