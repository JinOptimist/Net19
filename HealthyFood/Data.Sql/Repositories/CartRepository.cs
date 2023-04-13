using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class CartRepository: BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(WebContext webContext) : base(webContext) { }        

        public Cart GetByName(string name)
        {
            return _webContext.Carts.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
           var cart = _webContext.Carts.FirstOrDefault(x => x.Name == name);
            _webContext.Carts.Remove(cart);
            _webContext.SaveChanges();
        }

    }
}
