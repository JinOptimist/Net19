using Data.Interface.Models;
using Data.Interface.Repositories;

namespace HealthyFoodWeb.Services
{
    public interface IGameCatalogService
    {
        public List<ICatalog> GetCatalog();
    }
}