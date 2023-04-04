using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMcRepository : IBaseRepository<WikiMcImage>
    {
        IEnumerable<WikiMcImage> GetAllImgByYear(int year);
        IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type);
        void RemoveAllImgByYear(int year);
        void RemoveAllImgByType(ImgTypeEnum type);
    }
}
