using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IGameCatalogService
    {
        public List<GameCategory> GetCatalog();
        public void AddCategory(GameCatalogVeiwModel viewModel);
    }
}