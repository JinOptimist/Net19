using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;


namespace Data.Sql.Repositories
{
    public class CartRepository: ICartRepository
    {
        private WebContext _webContext;

        public CartRepository(WebContext webContext)
        {
            _webContext = webContext;
        }

        public void Add(ICartDbModel model)
        {
            _webContext.Carts.Add((CartModel)model);
            _webContext.SaveChanges();
        }

        public ICartDbModel Get(int id)
        {
            return _webContext.Carts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ICartDbModel> GetAll()
        {
            return _webContext.Carts.ToList();
        }

        public ICartDbModel GetByName(string name)
        {
            return _webContext.Carts.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(int id)
        {
            var cart = _webContext.Carts.FirstOrDefault(x => x.Id == id);
            _webContext.Carts.Remove(cart);
        }

        public void RemoveByName(string name)
        {
           var cart = _webContext.Carts.FirstOrDefault(x => x.Name == name);
            _webContext.Carts.Remove(cart);
        }
    }
}
