using Data.Interface.Models;

namespace HealthyFoodWeb.Models
{
    public class StoreCatalogueViewModel
    {
        public List<StoreItemViewModel> Items { get; set; }
        public List<ManufacturerViewModel> Manufacturer { get; set; }

    }
}
