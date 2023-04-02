using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class CartModel : BaseDbModel, ICartDbModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
