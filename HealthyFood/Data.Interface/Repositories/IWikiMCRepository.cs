using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMCRepository : IBaseRepository<IWikiMCDbModel>
    {
        IEnumerable<IWikiMCDbModel> GetAllImgByYear(int year);
        IEnumerable<IWikiMCDbModel> GetAllImgByType(ImgTypeEnum type);
        void RemoveAllImgByYear(int year);
        void RemoveAllImgByType(ImgTypeEnum type);
    }
}
