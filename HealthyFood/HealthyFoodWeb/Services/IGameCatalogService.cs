using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface IGameCatalogService
    {
        public List<ICatalogDbModel> GetCatalog();
        public void AddCategory(GameCatalogVeiwModel viewModel);
    }
}