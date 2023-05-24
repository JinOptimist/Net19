using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface ICartService
    {
        List<Cart> GetAllProduct();
        List<Cart> GetCustomerProduct();

        void DeleteFromCart(int id);
        void AddProductInBase(CartViewModel viewModel);

        PagginatorViewModel<CartViewModel> GetCartsForPaginator(int page, int perPage);


    }
}
