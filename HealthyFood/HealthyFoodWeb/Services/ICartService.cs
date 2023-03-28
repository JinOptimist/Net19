using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface ICartService
    {
        List<ICartModel> GetAllProduct();

        void DeleteFromCart(string name);
    }
}
