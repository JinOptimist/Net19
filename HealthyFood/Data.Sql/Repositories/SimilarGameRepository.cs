using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class SimilarGameRepository : ISimilarGameRepository
    {
        private WebContext _webContext;

        public SimilarGameRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(SimilarGame model)
        {
            _webContext.SimilarGames.Add((SimilarGame)model);
            _webContext.SaveChanges();
        }

        public SimilarGame Get(int id)
        {
           return _webContext.SimilarGames.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SimilarGame> GetAll()
        {
           return _webContext.SimilarGames.ToList();
        }

        public void Remove(int id)
        {
           var gameForRemove = _webContext.SimilarGames.FirstOrDefault(x => x.Id == id);
            _webContext.SimilarGames.Remove(gameForRemove); 
        }
        public void Remove(string name)
        {
            var gameForRemove = _webContext.SimilarGames.FirstOrDefault(x => x.Name == name);
            _webContext.SimilarGames.Remove(gameForRemove);
            _webContext.SaveChanges();
        }
    }
}
