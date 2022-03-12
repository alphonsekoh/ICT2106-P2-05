using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PainAssessment.Areas.ModuleTwo.Models.CalculateWeightageModels
{
    public class WeightageObjectFromThreeStrings : IWeightageObjectFromThreeFields
    {
        private string _local;
        private string _central;
        private string _regional;

        public WeightageObjectFromThreeStrings(string local, string central, string regional)
        {
            this._local = local;
            this._central = central;
            this._regional = regional;
        }
        public ReadOnlyDictionary<string, double> getThreeWeightagesAsStrDoubleDict()
        {
            double doubleLocal = System.Math.Round(double.Parse(this._local, System.Globalization.CultureInfo.InvariantCulture),
                                                   2, System.MidpointRounding.AwayFromZero);
            double doubleCentral = System.Math.Round(double.Parse(this._central, System.Globalization.CultureInfo.InvariantCulture),
                                                     2, System.MidpointRounding.AwayFromZero);
            double doubleRegional = System.Math.Round(double.Parse(this._regional, System.Globalization.CultureInfo.InvariantCulture),
                                                      2, System.MidpointRounding.AwayFromZero);

            IDictionary<string, double> dict = new Dictionary<string, double>()
            {
                { "local", doubleLocal },
                { "central", doubleCentral },
                { "regional", doubleRegional }
            };
            return new ReadOnlyDictionary<string, double>(dict);
        }
    }
}
