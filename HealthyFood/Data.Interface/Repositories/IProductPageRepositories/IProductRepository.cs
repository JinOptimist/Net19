using Data.Interface.Models;
using Data.Interface.Models.ProductPage;
using Data.Interface.Repositories;

namespace Data.Interface.Repositories.IProductPageRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetExpensiveProductWithCategories();
        void UpdateRating(int id, decimal rating);
    }
}