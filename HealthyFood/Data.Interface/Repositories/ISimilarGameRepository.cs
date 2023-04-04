
using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface ISimilarGameRepository : IBaseRepository<ISimilarGamesDbModel>
    {
        public void Remove(string name);
      
    }
}
