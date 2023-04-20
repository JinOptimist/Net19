using Data.Interface.Models;
using HealthyFoodWeb.Models.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models
{
    public class StoreItemViewModel
    {
        [Required] 
        public string Name { get; set; }
        [Positive]
        public decimal Price { get; set; }
        public string Img { get; set; }
        public string Manufacturer { get; set; }

        public List<SelectListItem>? AllManufacturers { get; set; }

    }
}