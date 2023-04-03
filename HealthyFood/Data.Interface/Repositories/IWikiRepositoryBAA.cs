using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiRepositoryBAA : IBaseRepository<IBlockModelBAA>
    {
        void RemoveBlock(int id);
        IBlockModelBAA GetBlockId(int id);
    }
}