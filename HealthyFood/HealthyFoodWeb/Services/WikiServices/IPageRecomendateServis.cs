using Data.Interface.Models;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services.WikiServices
{
    public interface IPageRecomendateServis
    {
        List<IBlockModelBAA> GetTitles();
    }
}