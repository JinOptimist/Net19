using Data.Interface.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthyFoodWeb.Models
{
    public class StoreItemViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public string Manufacturer { get; set; }

        public List<SelectListItem> AllManufacturers { get; set; }

    }
}