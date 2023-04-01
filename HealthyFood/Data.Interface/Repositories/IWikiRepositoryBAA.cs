using Data.Interface.Models;

namespace HealthyFoodWeb.Services.FakeDb
{
    public interface IWikiRepositoryBAA
    {
        List<IBlockModelBAA> GetBlocks();
        void CreateBlock(IBlockModelBAA block);
        void RemoveBlock(int id);
        IBlockModelBAA GetBlockId(int id);
        
    }
}