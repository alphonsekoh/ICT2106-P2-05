using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PainAssessment.Areas.ModuleTwo.Models.CalculateWeightageModels
{
    public interface IWeightageObjectFromThreeFields
    {
        public ReadOnlyDictionary<string,double> getThreeWeightagesAsStrDoubleDict();
    }
}
