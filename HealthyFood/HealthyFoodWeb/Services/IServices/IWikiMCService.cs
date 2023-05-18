using Data.Interface.DataModels;
using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.Games;

namespace HealthyFoodWeb.Services
{
	public interface IWikiMcService
	{
		void AddImg(WikiMcViewModel viewModel);

		IEnumerable<WikiMcImage> GetAllImgByYear();

		IEnumerable<WikiMcImage> GetAllImgByType();

		IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages();

        ImagesAndPaginatorData GetImagesForPaginator(int page, int perPage);

        WikiMcViewModel GetImageViewModel(int id);

        void RemoveByType(ImgTypeEnum type);

		void RemoveByYear(int year);

        void UpdateAllExсeptTags(int id, ImgTypeEnum type, string imgUrl, int year);

        void UpdateTags(int id, List<string> tags);

		WikiMcImagesCountViewModel GetViewModelForImagesCount(int? year, string? tag, ImgTypeEnum type);
	}
}
