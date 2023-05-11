namespace HealthyFoodWeb.Models
{
    public class ProductPageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }
        public List<string> ProductCategories { get; set; } = new List<string>();

        public List<decimal> ProductContain { get; set; } = new List<decimal>();
          
    }
}
