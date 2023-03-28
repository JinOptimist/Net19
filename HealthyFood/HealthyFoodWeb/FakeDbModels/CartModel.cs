using Data.Interface.Models;
using HealthyFoodWeb.Services;

namespace HealthyFoodWeb.FakeDbModels
{
    public class CartModel : ICartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
