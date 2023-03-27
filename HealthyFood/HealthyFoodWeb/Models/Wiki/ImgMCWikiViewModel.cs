using Data.Interface.Models;
using HealthyFoodWeb.Models.WikiModels;

namespace HealthyFoodWeb.Models.Wiki
{
    public class ImgMCWikiViewModel
    {
        public List<MacronutrientCalculatorIMGViewModel> ImgByYear { get; set; }
        public List<MacronutrientCalculatorIMGViewModel>  ImgByType { get; set; }
    }
}
