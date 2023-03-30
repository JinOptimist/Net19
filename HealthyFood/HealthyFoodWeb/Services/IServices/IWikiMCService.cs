using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface IWikiMCService
    {
        void AddImg(WikiMCViewModel viewModel);

        List<IWikiMCDbModel> GetAllImgByYear();

        List<IWikiMCDbModel> GetAllImgByType();

        void RemoveByType(string type);

        void RemoveByYear(int  year);
    }
}
