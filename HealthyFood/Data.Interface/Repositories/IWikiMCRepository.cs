using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMCRepository : IBaseRepository<IWikiMCDbModel>
    {
        IEnumerable<IWikiMCDbModel> GetAllImgByYear(int year);
        IEnumerable<IWikiMCDbModel> GetAllImgByType(string type);
        void RemoveAllImgByYear(int year);
        void RemoveAllImgByType(string type);
    }
}
