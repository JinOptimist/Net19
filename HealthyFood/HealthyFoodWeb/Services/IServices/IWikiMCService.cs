using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
	public interface IWikiMCService
	{
		void AddImg(WikiMCViewModel viewModel);

		IEnumerable<WikiMcImage> GetAllImgByYear();

		IEnumerable<WikiMcImage> GetAllImgByType();

		void RemoveByType(ImgTypeEnum type);

		void RemoveByYear(int year);

		IEnumerable<WikiMcImage> GetAllImageWithTags();
	}
}
