
namespace Data.Interface.Models.WikiMc
{
	public class WikiCalculationResults : BaseModel
	{
		public int AverageCalculatedCalories { get; set; }

		public int GramsProtein { get; set; }

		public int GramsFat { get; set; }

		public int GramsCarb { get; set; }

		public int CalculatorUserId { get; set; }

		public virtual User CalculatorUser { get; set; }
	}
}
