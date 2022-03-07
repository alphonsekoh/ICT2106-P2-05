using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PainAssessment.Areas.ModuleTwo.Services
{
    public interface ICalculateWeightageService
    {
        public ReadOnlyDictionary<string, double> calcWeightageFromThreeInputs(double localInput, double centralInput, double regionalInput);
        public ReadOnlyDictionary<string, double> calcWeightageFromThreeInputs(string localInput, string centralInput, string regionalInput);
    }
}
