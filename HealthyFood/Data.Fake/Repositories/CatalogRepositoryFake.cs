using Data.Interface.Models;

namespace Data.Fake.Repositories
{
    public class CatalogRepositoryFake : BaseRepository<GameCategory>
    {
        public CatalogRepositoryFake()
        {
            FakeDbModels
                = new List<GameCategory>(){
                    new GameCategory()
                    {
                        Id = 1,
                        Name = "Ходилки"
                    },

                    new GameCategory()
                    {
                        Name = "Бродилки"
                    },

                     new GameCategory()
                    {
                        Name = "Три в ряд"
                    }
                };
        }


    }


}

