namespace PainAssessment.Areas.ModuleTwo.Models.CalculateWeightageModels
{
    public class WeightageObjectFromThreeFieldsFactory
    {
        public WeightageObjectFromThreeFieldsFactory() { }
        
        public static IWeightageObjectFromThreeFields makeWeightageObjectFromThreeFields(double local, double central, double regional)
        {
            return new WeightageObjectFromThreeDoubles(local, central, regional);
        }

        public static IWeightageObjectFromThreeFields makeWeightageObjectFromThreeFields(string local, string central, string regional)
        {
            return new WeightageObjectFromThreeStrings(local, central, regional);
        }
    }
}
