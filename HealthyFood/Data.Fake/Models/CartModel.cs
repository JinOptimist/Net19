using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class CartModel : ICartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
