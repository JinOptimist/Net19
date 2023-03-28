using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface ICartService
    {
        List<ICartModel> GetAllProduct();

        void DeleteFromCart(string name);
    }
}
