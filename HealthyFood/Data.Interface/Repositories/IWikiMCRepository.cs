using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMCRepository : IBaseRepository<IWikiMCDbModel>
    {
        IWikiMCDbModel GetImgByYear(int year);
        IWikiMCDbModel GetImgByType(string type);
        void RemoveByYear(int year);
        void RemoveByType(string type);
    }
}
