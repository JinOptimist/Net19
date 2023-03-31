using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface IWikiMCService
    {
        void AddImg(WikiMCViewModel viewModel);

        IEnumerable<IWikiMCDbModel> GetAllImgByYear();

        IEnumerable<IWikiMCDbModel> GetAllImgByType();

        void RemoveByType(string type);

        void RemoveByYear(int  year);
    }
}
