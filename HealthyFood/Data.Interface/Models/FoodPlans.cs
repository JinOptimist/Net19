namespace Data.Interface.Models
{
	public class FoodPlans : BaseModel
	{
		public string Name { get; set; }

		public string Cover { get; set; }

		public int Price { get; set; }

		public int DiscountPrice { get; set; }

		public int Calories { get; set; }

		public int Proteins { get; set; }

		public int Fats { get; set; }

		public int Carbs { get; set; }
	}
}