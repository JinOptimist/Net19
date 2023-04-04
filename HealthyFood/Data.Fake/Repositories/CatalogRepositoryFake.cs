

using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace Data.Fake.Repositories
{
    public class CatalogRepositoryFake : BaseRepository<ICatalogDbModel>
    {
        public CatalogRepositoryFake()
        {
            FakeDbModels
                = new List<ICatalogDbModel>(){
                    new CatalogDbModel()
                    {
                        Id = 1,
                        NameCategory = "Ходилки"
                    },

                    new CatalogDbModel()
                    {
                        NameCategory = "Бродилки"
                    },

                     new CatalogDbModel()
                    {
                        NameCategory = "Три в ряд"
                    }
                };
        }


    }


}

