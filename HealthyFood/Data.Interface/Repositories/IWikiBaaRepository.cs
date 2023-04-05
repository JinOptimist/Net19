using Data.Interface.Models;
using Data.Sql.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiBaaRepository : IBaseRepository<Block>
    {
        void RemoveBlock(int id);
    }
}