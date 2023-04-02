using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class SimilarGameRepository : ISimilarGameRepository
    {
        private WebContext _webContext;

        public SimilarGameRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(ISimilarGamesDbModel model)
        {
            _webContext.SimilarGamesDbModels.Add((SimilarGamesDbModel)model);
        }

        public ISimilarGamesDbModel Get(int id)
        {
           return _webContext.SimilarGamesDbModels.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ISimilarGamesDbModel> GetAll()
        {
            return _webContext.SimilarGamesDbModels.ToList();
        }

        public void Remove(int id)
        {
           var gameForRemove = _webContext.SimilarGamesDbModels.FirstOrDefault(x => x.Id == id);
            _webContext.SimilarGamesDbModels.Remove(gameForRemove); 
        }
    }
}
