using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface ICartService
    {
        List<Cart> GetAllProduct();

        void DeleteFromCart(string name);
        void AddProductInBase(CartViewModel viewModel);
    }
}
