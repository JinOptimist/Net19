using Data.Interface.DataModels;
using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
	public interface IWikiMcService
	{
		void AddImg(WikiMcViewModel viewModel);

		IEnumerable<WikiMcImage> GetAllImgByYear();

		IEnumerable<WikiMcImage> GetAllImgByType();

		IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages();

        ImagesAndPaginatorData GetImagesForPaginator(int page, int perPage);

        void RemoveByType(ImgTypeEnum type);

		void RemoveByYear(int year);
	}
}
