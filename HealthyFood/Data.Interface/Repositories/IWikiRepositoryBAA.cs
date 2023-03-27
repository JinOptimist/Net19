using Data.Interface.Models;

namespace HealthyFoodWeb.Services.FakeDb
{
    public interface IWikiRepositoryBAA
    {
        List<IBlockModelBAA> GetTitles();
    }
}