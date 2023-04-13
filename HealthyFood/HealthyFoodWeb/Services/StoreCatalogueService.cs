using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class StoreCatalogueService : IStoreCatalogueService
    {
        private IStoreCatalogueRepository _catalogueRepository;
        private IManufacturerRepository _manufacturerRepository;

        public StoreCatalogueService(IStoreCatalogueRepository catalogueRepositories, IManufacturerRepository manufacturerRepository)
        {
            _catalogueRepository = catalogueRepositories;
            _manufacturerRepository = manufacturerRepository;
        }

        public List<StoreItem> GetAllItems()
        {
            return _catalogueRepository.GetAll().ToList();
        }

        public List<Manufacturer> GetAllManufacturer()
        {
            return _manufacturerRepository.GetAll().ToList();
        }
    }
}

