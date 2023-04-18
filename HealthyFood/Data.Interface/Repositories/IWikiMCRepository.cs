using Data.Interface.Models;
using Data.Sql.Models;

namespace Data.Interface.Repositories
{
	public interface IWikiMcRepository : IBaseRepository<WikiMcImage>
	{
		IEnumerable<WikiMcImage> GetAllImgByYearWithTags(int year);
		IEnumerable<WikiMcImage> GetAllImgByYear(int year);
		IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type);
        IEnumerable<WikiMcImage> GetImagesByUserId(int userId);
        void RemoveAllImgByYear(int year);
		void RemoveAllImgByType(ImgTypeEnum type);
	}
}
