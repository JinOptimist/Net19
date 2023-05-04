using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public StoreItemViewModel GetStoreViewModel(int id)
        {
            var storeDb = _catalogueRepository.GetItemWithManufacturer(id);
            var manufacturers = _manufacturerRepository
                .GetAll()
                .Select(x => x.Name)
                .Select(x => new SelectListItem
                 {
                   Text = x,
                   Value = x
                 })
                 .ToList();

            return new StoreItemViewModel
            {
                Id = storeDb.Id,
                Name = storeDb.Name,
                Img = storeDb.ImageUrl,
                Price = storeDb.Price,
                AllManufacturers = manufacturers,
                Manufacturer = storeDb.Manufacturer.Name   
            };

        }

        public void UpdateItem(StoreItemViewModel storeItemViewModel)
        {
            var manufacturer = _manufacturerRepository.GetByName(storeItemViewModel.Manufacturer);
            _catalogueRepository.UpdateItem(storeItemViewModel.Id,
                storeItemViewModel.Name,
                storeItemViewModel.Price,
                storeItemViewModel.Img,
                manufacturer
                );
        }
    }
}

