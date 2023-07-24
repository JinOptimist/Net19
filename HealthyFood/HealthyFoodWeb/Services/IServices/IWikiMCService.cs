using Data.Interface.DataModels;
using Data.Interface.Models.WikiMc;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.WikiMcModels;
using static HealthyFoodWeb.Services.WikiServices.WikiMCService;

namespace HealthyFoodWeb.Services
{
	public interface IWikiMcService
	{
		void AddImg(WikiMcViewModel viewModel);

		IEnumerable<WikiMcImage> GetAllImgByYear();

		IEnumerable<WikiMcImage> GetAllImgByType();

		//void AddUserCalcultionResult(int averageAns, int gramsOfProteins, int gramsOfCarbs, int gramsOfFats);

		//void UpdateUserCalcultionResult(int averageAns, int gramsOfProteins, int gramsOfCarbs, int gramsOfFats);

		IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages();

		WikiMcViewModel GetImageViewModel(int id);

		void DeleteImageByType(ImgTypeEnum type);

		void DeleteImageByYear(int year);

		void DeleteImage(int imgId);

		void UpdateAllExсeptTags(int id, ImgTypeEnum type, string imgUrl, int year);

		void UpdateTags(int id, List<string> tags);

		IEnumerable<WikiTags> GetAllUserTags(int userId);

		WikiMcImagesCountViewModel GetViewModelForImagesCount(int? year, string tag, ImgTypeEnum type);

		WikiCalculationResultViewModel GetViewModelForCaloriesCalculation(int? age, float? weight, float? height, int? percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio, int? proteinsPercent, int? fatsPercent, int? carbsPercent);

		PagginatorViewModel<WikiMcViewModel> GetImagesForPaginator(int page, int perPage);

		ShowUploadedImagesViewModel GetShowUploadedImagesViewModel(int page, int perPage);

		float CalculateCaloriesViaHarrisBenedict(int age, float weight, float height, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio);

		float CalculateCaloriesViaMifflinStJeor(int age, float weight, float height, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio);

		float CalculateCaloriesViaWho(int age, float weight, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio);

		float CalculateAverageCalories(float harrisBenedictAns, float mifflinStJeorAns, float whoAns);

		Nutrients CalculateGramsOfNutrients(float calories, int proteinsPercent, int fatsPercent, int carbsPercent);
	}
}