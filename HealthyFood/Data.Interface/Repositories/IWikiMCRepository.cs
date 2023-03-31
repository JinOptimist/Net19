using Data.Fake.Models;
using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMCRepository : IBaseRepository<IWikiMCDbModel>
    {
        IEnumerable<IWikiMCDbModel> GetAllImgByYear(int year);
        IEnumerable<IWikiMCDbModel> GetAllImgByType(ImgTypeDbModel type);
        void RemoveAllImgByYear(int year);
        void RemoveAllImgByType(ImgTypeDbModel type);
    }
}
