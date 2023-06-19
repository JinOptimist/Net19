namespace HealthyFoodWeb.Models
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }
        
    }
}
