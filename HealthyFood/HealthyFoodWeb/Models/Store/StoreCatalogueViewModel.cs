using Data.Interface.Models;

namespace HealthyFoodWeb.Models.Store
{
    public class StoreCatalogueViewModel
    {
        public StoreAndPagginatorViewModel ItemsPaginator { get; set; }
        public List<ManufacturerViewModel> Manufacturer { get; set; }

    }
}
