using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IStoreCatalogueService
    {
        List<StoreItem> GetAllItems();
        List<Manufacturer> GetAllManufacturer();

    }
}
