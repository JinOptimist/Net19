namespace HealthyFoodWeb.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }

        public List<string> Customers { get; set; } = new List<string>();


    }
}
