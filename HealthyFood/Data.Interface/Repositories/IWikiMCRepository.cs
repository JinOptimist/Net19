using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Sql.DataModels;

namespace Data.Interface.Repositories
{
    public interface IWikiMcRepository : IBaseRepository<WikiMcImage>
    {
		IEnumerable<WikiMcImage> GetAllImgByYearWithTags(int year);
		IEnumerable<WikiMcImage> GetAllImgByYear(int year);
        IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type);
        List<ImagesAndInfoAboutTheirUploaderData> GetUserImages();
        ImagesAndPaginatorData GetImagesForPaginator(int page, int perPage);
        void RemoveAllImgByYear(int year);
        void RemoveAllImgByType(ImgTypeEnum type);
    }
}