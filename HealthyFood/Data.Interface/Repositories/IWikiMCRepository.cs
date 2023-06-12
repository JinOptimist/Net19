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
        void DeleteImgByYear(int year);
        void DeleteImgByType(ImgTypeEnum type);
		void DeleteImage(int idImg);
		WikiMcImage GetImageAndTags(int id);
        void UpdateAllExeptTags(int id, ImgTypeEnum type, string imgUrl, int year);
        IQueryable<ImagesAndInfoAboutTheirUploaderData> GetUserImagesIQueryable();
		ImagesCountData GetDataForImagesCount(int? year, string? tag, ImgTypeEnum type);
	}
}