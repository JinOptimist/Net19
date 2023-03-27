using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.WikiModels;

namespace HealthyFoodWeb.Services
{
    public interface IWikiMCImgService
    {
        void AddImg(MacronutrientCalculatorIMGViewModel viewModel);

        List<IWiki_MC_Img_Model> GetAllImgByYear();

        List<IWiki_MC_Img_Model> GetAllImgByType();

        void RemoveByType(string type);

        void RemoveByYear(int  year);
    }
}
