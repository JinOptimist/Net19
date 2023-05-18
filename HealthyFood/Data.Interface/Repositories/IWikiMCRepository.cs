using Data.Interface.DataModels;
using Data.Interface.Models;

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
        WikiMcImage GetImageAndTags(int id);
        void UpdateAllExeptTags(int id, ImgTypeEnum type, string imgUrl, int year);
        IQueryable<ImagesAndInfoAboutTheirUploaderData> GetUserImagesIQueryable();
    }
}