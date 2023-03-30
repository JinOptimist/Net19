using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Migrations;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class HealthyProductRepository : IHealthyProductRepository
    {
        private WebContext _webContext;

        public HealthyProductRepository(WebContext webContext)
        {
            _webContext = webContext;
        }

        public void Add(IHealthyProductDbModel model)
        {
            _webContext.HealthyProducts.Add((HealthyProductDbModel)model);
            _webContext.SaveChanges();
        }

        public IHealthyProductDbModel Get(int id)
        {
            return _webContext.HealthyProducts.FirstOrDefault(x => x.Id == id);
        }

        public IHealthyProductDbModel GetByName(string name)
        {
            return _webContext.HealthyProducts.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            var healthyProduct = _webContext.HealthyProducts.FirstOrDefault(_x => _x.Name == name);
            _webContext.HealthyProducts.Remove(healthyProduct);
        }
        public IEnumerable<IHealthyProductDbModel> GetAll()
        {
            return _webContext.HealthyProducts.ToList();
        }

        public void Remove(int id)
        {
            var healthyProduct = _webContext.HealthyProducts.FirstOrDefault(_x => _x.Id == id);
            _webContext.HealthyProducts.Remove(healthyProduct);
        }
    }
}

