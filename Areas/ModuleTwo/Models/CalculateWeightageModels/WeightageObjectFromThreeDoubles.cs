using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PainAssessment.Areas.ModuleTwo.Models.CalculateWeightageModels
{
    public class WeightageObjectFromThreeDoubles : IWeightageObjectFromThreeFields
    {
        private double _local;
        private double _central;
        private double _regional;

        public WeightageObjectFromThreeDoubles(double local, double central, double regional)
        {
            this._local = local;
            this._central = central;
            this._regional = regional;
        }

        public ReadOnlyDictionary<string, double> getThreeWeightagesAsStrDoubleDict()
        {
            IDictionary<string, double> dict = new Dictionary<string, double>()
            {
                {"local", _local},
                {"central", _central },
                {"regional", _regional}
            };
            return new ReadOnlyDictionary<string, double>(dict);
        }
    }
}
