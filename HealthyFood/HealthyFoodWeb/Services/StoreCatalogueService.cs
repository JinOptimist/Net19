using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
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
            return _catalogueRepository.GetItemsWithManufacturer();
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _manufacturerRepository.GetAll().ToList();
        }

        public void AddStoreItem(StoreItemViewModel viewModel) 
        {
            var manufacturer = _manufacturerRepository.GetByName(viewModel.Manufacturer);
            var dbCartModel = new StoreItem()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImageUrl = viewModel.Img,
                Manufacturer = manufacturer,
            };

            _catalogueRepository.Add(dbCartModel);
        }

        public StoreCatalogueViewModel CreateStoreViewModel()
        {
            var viewModel = new StoreCatalogueViewModel();
            viewModel.Items = GetAllItems()
                .Select(x => new StoreItemViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Img = x.ImageUrl,
                    Manufacturer = x.Manufacturer.Name,

                }).ToList();
            viewModel.Manufacturer = GetAllManufacturers()
                .Select(x => new ManufacturerViewModel
                {
                    Name = x.Name,
                }).ToList();

            return viewModel;

        }
    }
}

