using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Data.Sql.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(WebContext webContext) : base(webContext) { }

        public Cart GetByName(string name)
        {
            return _webContext.Carts.FirstOrDefault(x => x.Name == name);
        }

        public override PaginatorData<Cart> GetPaginator(int page, int perPage, Func<List<Cart>> filteredDataFunc)
        {
            var initialSource = filteredDataFunc().AsQueryable();
            return GetPaginator(initialSource, page, perPage);
        }

        public override PaginatorData<Cart> GetPaginator(IQueryable<Cart> initialSource, int page, int perPage)
        {
            var dataModel = new PaginatorData<Cart>();

            var items = initialSource
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();
            dataModel.Items = items;
            dataModel.TotalCount = initialSource.Count();
            return dataModel;
        }

    }
}
