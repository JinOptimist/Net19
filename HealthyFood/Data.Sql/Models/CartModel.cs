using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class CartModel : BaseDbModel, ICartDbModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
