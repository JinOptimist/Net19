using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services.FakeDb
{
    public class CatalogOfGameFrit : ICatalogRepositories
    {
        public static List<ICatalog> FakeDbCatolog =
            new List<ICatalog>() {
                new Catalog
                {
                    Id = 1,
                    NameCategory = "Ходилки"
                   },
                new Catalog
                 {
                    Id = 2,
                    NameCategory = "Бродилки"
                   },
                new Catalog
                 {
                    Id = 3,
                    NameCategory = "Три в ряд"
                   },
            };
        public List<ICatalog> GetCatalog()
        {
            return FakeDbCatolog;
        }

    }
}
