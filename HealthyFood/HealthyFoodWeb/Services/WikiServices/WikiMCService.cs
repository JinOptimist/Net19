using Data.Interface.DataModels;
using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.WikiMcModels;
using HealthyFoodWeb.Services.Helpers;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services.WikiServices
{
	public class WikiMCService : IWikiMcService
	{
		public struct Nutrients
		{
			public float gramsOfProteins;
			public float gramsOfFats;
			public float gramsOfCarbs;
		}

		public const int CURRENT_YEAR = 2023;

		readonly Dictionary<ActivityRatioEnum, float> activityRatioValues = new Dictionary<ActivityRatioEnum, float>()
		{
			[ActivityRatioEnum.Minimum] = 1.20f,
			[ActivityRatioEnum.Low] = 1.375f,
			[ActivityRatioEnum.Average] = 1.46f,
			[ActivityRatioEnum.AboveAverage] = 1.55f,
			[ActivityRatioEnum.Increased] = 1.64f,
			[ActivityRatioEnum.High] = 1.72f,
			[ActivityRatioEnum.VeryHigh] = 1.90f,
		};

		private IWikiMcRepository _wikiMcRepository;
		private IWikiMcService _wikiMCImgService;
		private IWikiTagRepository _tagRepository;
		private IAuthService _authService;
		private IPagginatorService _paginatorService;
		private IWebHostEnvironment _webHostEnvironment;
		private IWikiCalculationResultRepository _wikiCalculationResultRepository;

		public WikiMCService(IWikiMcRepository wikiMCRepository, IAuthService authService, IWikiTagRepository tagService, IPagginatorService paginatorService, IWebHostEnvironment webHostEnvironment, IWikiCalculationResultRepository wikiCalculationResultRepository, IWikiMcService wikiMcService)
		{
			_wikiMcRepository = wikiMCRepository;
			_authService = authService;
			_tagRepository = tagService;
			_paginatorService = paginatorService;
			_webHostEnvironment = webHostEnvironment;
			_wikiCalculationResultRepository = wikiCalculationResultRepository;
			_wikiMCImgService = wikiMcService;
		}

		public void AddImg(WikiMcViewModel viewModel)
		{

			var user = _authService.GetUser();
			var dbWikiMcModel = new WikiMcImage()
			{
				ImgType = viewModel.ImgType,
				ImgUrl = "temp",
				Year = viewModel.Year,
				ImageUploader = user,
				Tags = new List<WikiTags>()
			};

			var tags = viewModel.EnteredTags.Split(',').ToList();
			foreach (var tag in tags)
			{
				var dbTag = _tagRepository.Get(tag);
				if (dbTag == null)
				{
					dbTag = _tagRepository.Add(new WikiTags { TagName = tag });
				}

				dbWikiMcModel.Tags.Add(dbTag);
			}

			_wikiMcRepository.Add(dbWikiMcModel);

			var ext = Path.GetExtension(viewModel.ImageCover.FileName);
			var fileName = $"image-{dbWikiMcModel.Id}{ext}";
			var path = Path.Combine(
				_webHostEnvironment.WebRootPath,
				"images",
				"wiki",
				fileName);

			using (var fs = File.Create(path))
			{
				viewModel.ImageCover.CopyTo(fs);
			}

			dbWikiMcModel.ImgUrl = $"/images/wiki/{fileName}";
			_wikiMcRepository.Update(dbWikiMcModel);
		}

		public IEnumerable<WikiMcImage> GetAllImgByYear()
		{
			return _wikiMcRepository
				.GetAll()
				.Where(x => x.Year == CURRENT_YEAR)
				.ToList();
		}

		public IEnumerable<WikiMcImage> GetAllImgByType()
		{
			return _wikiMcRepository
				.GetAll()
				.Where(x => x.ImgType == ImgTypeEnum.Proteins)
				.ToList();
		}

		public void DeleteImageByType(ImgTypeEnum type)
		{
			_wikiMcRepository.DeleteImgByType(type);
		}

		public void DeleteImageByYear(int year)
		{
			_wikiMcRepository.DeleteImgByYear(year);
		}

		public void DeleteImage(int imgId)
		{
			_wikiMcRepository.DeleteImage(imgId);
		}

		public IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
		{
			return _wikiMcRepository.GetUserImages();
		}

		public IEnumerable<WikiTags> GetAllUserTags(int userId)
		{
			return _tagRepository.GetAllUserTags(userId);
		}

		public WikiMcViewModel GetImageViewModel(int id)
		{
			var imageDb = _wikiMcRepository.GetImageAndTags(id);
			var tags = _tagRepository
				.GetAll()
				.Select(x => x.TagName)
				.ToList();

			return new WikiMcViewModel
			{
				Id = imageDb.Id,
				ImgType = imageDb.ImgType,
				ImgUrl = imageDb.ImgUrl,
				Year = imageDb.Year,
				UserTagsForImage = imageDb.Tags.Select(x => x.TagName).ToList()
			};
		}

		public void UpdateAllExсeptTags(int id, ImgTypeEnum type, string imgUrl, int year)
		{
			_wikiMcRepository.UpdateAllExeptTags(id, type, imgUrl, year);
		}

		public void UpdateTags(int id, List<string> newTagsNames)
		{
			var image = _wikiMcRepository.GetImageAndTags(id);
			if (image.Tags == null)
			{
				image.Tags = new List<WikiTags>();
			}

			var newTags = _tagRepository
				.GetAll()
				.Where(tag => newTagsNames.Contains(tag.TagName))
				.ToList();

			image.Tags.RemoveAll(x => true);

			newTags.ForEach(tag => image.Tags.Add(tag));

			_wikiMcRepository.Update(image);
		}

		public WikiMcImagesCountViewModel GetViewModelForImagesCount(int? year, string? tag, ImgTypeEnum type)
		{
			var dataModel = _wikiMcRepository.GetDataForImagesCount(year, tag, type);
			return new WikiMcImagesCountViewModel
			{
				TotalImagesCount = dataModel.Count,
				ImagesUrl = dataModel.ImagesUrl
			};
		}

		public PagginatorViewModel<WikiMcViewModel> GetImagesForPaginator(int page, int perPage)
		{
			var viewModel = _paginatorService
				.GetPaginatorViewModel(
					page,
					perPage,
					BuildWikiMcViewModelFromDbModel,
					_wikiMcRepository);

			return viewModel;
		}

		private WikiMcViewModel BuildWikiMcViewModelFromDbModel(WikiMcImage x)
		{
			return new WikiMcViewModel
			{
				Id = x.Id,
				Year = x.Year,
				ImgUrl = x.ImgUrl,
				ImgType = x.ImgType,
				UserTagsForImage = x.Tags?.Select(x => x.TagName).ToList() ?? new List<string>()
			};
		}

		public ShowUploadedImagesViewModel GetShowUploadedImagesViewModel(int page, int perPage)
		{
			var viewModel = new ShowUploadedImagesViewModel();

			var user = _authService.GetUser();
			viewModel.PaginatorViewModel = _paginatorService
				.GetPaginatorViewModel(
					page,
					perPage,
					BuildWikiMcViewModelFromDbModel,
					_wikiMcRepository);
			viewModel.AllUserTags = _tagRepository.GetAllUserTags(user.Id).ToList();

			return viewModel;
		}

		private void SexConstForHarrisBenedict(SexEnum sex, out float firstConst, out float weightConst, out float heightConst, out float ageConst)
		{
			if (sex == SexEnum.Male)
			{
				firstConst = 66f;
				weightConst = 13.7f;
				heightConst = 5f;
				ageConst = 6.8f;
			}
			else
			{
				firstConst = 655f;
				weightConst = 9.6f;
				heightConst = 1.8f;
				ageConst = 4.7f;
			}
		}

		private int SexConstForMifflinsStJeor(SexEnum sex) => sex == SexEnum.Male ? 5 : -161;

		private void SexAndAgeConstForWho(SexEnum sex, int age, ActivityRatioEnum activityRatio, out float weightConst, out float secondConst, out float activityRatioValue)
		{
			weightConst = 0f;
			secondConst = 0f;
			activityRatioValue = 0f;

			switch (activityRatio)
			{
				case ActivityRatioEnum.Minimum:
					activityRatioValue = 1.0f;
					break;
				case ActivityRatioEnum.Low:
					activityRatioValue = 1.0f;
					break;
				case ActivityRatioEnum.Average:
					activityRatioValue = 1.3f;
					break;
				case ActivityRatioEnum.AboveAverage:
					activityRatioValue = 1.3f;
					break;
				case ActivityRatioEnum.Increased:
					activityRatioValue = 1.5f;
					break;
				case ActivityRatioEnum.High:
					activityRatioValue = 1.5f;
					break;
				case ActivityRatioEnum.VeryHigh:
					activityRatioValue = 1.5f;
					break;
			}

			switch (sex)
			{
				case SexEnum.Male:
					{
						if (age <= 30)
						{
							weightConst = 0.063f;
							secondConst = 2.896f;
						}
						if (age > 30 && age <= 60)
						{
							weightConst = 0.0484f;
							secondConst = 3.653f;
						}
						if (age > 60)
						{
							weightConst = 0.0491f;
							secondConst = 2.459f;
						}
						break;
					}
				case SexEnum.Female:
					{
						if (age <= 30)
						{
							weightConst = 0.062f;
							secondConst = 2.036f;
						}
						if (age > 30 && age <= 60)
						{
							weightConst = 0.034f;
							secondConst = 3.538f;
						}
						if (age > 60)
						{
							weightConst = 0.038f;
							secondConst = 2.755f;
						}
						break;
					}
				default:
					throw new NotImplementedException();
			}
		}

		private float GetMultiplierForGoal(GoalEnum goal, int percent)
		{
			switch (goal)
			{
				case GoalEnum.Weight_loss:
					return (100f - percent) / 100f;
				case GoalEnum.Weight_gain:
					return (100f + percent) / 100f;
				case GoalEnum.Weight_maintenance:
					return 1f;
				default:
					throw new NotImplementedException();
			}
		}

		public float CalculateCaloriesViaHarrisBenedict(int age, float weight, float height, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio)
		{
			SexConstForHarrisBenedict(sex, out float firstConst, out float weightConst, out float heightConst, out float ageConst);
			return (firstConst + weightConst * weight + heightConst * height - ageConst * age) * activityRatioValues[activityRatio] * GetMultiplierForGoal(goal, percent);
		}

		public float CalculateCaloriesViaMifflinStJeor(int age, float weight, float height, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio)
		{
			return (9.99f * weight + 6.25f * height - 4.92f * age + SexConstForMifflinsStJeor(sex)) * activityRatioValues[activityRatio] * GetMultiplierForGoal(goal, percent);
		}

		public float CalculateCaloriesViaWho(int age, float weight, int percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio)
		{
			SexAndAgeConstForWho(sex, age, activityRatio, out float weightConst, out float secondConst, out float activityRatioValue);
			return (weightConst * weight + secondConst) * activityRatioValue * 240f * GetMultiplierForGoal(goal, percent);
		}

		public float CalculateAverageCalories(float harrisBenedictAns, float mifflinStJeorAns, float whoAns)
		{
			return (harrisBenedictAns + mifflinStJeorAns + whoAns) / 3;
		}

		public Nutrients CalculateGramsOfNutrients(float calories, int proteinsPercent, int fatsPercent, int carbsPercent)
		{
			const int CALORIES_PER_G_PROTEIN = 4;
			const int CALORIES_PER_G_FAT = 9;
			const int CALORIES_PER_G_CARB = 4;

			var gramsOfProteins = (calories * proteinsPercent / 100f) / CALORIES_PER_G_PROTEIN;
			var gramsOfFats = (calories * fatsPercent / 100f) / CALORIES_PER_G_FAT;
			var gramsOfCarbs = (calories * carbsPercent / 100f) / CALORIES_PER_G_CARB;

			return new Nutrients { gramsOfProteins = gramsOfProteins, gramsOfFats = gramsOfFats, gramsOfCarbs = gramsOfCarbs };
		}

		public WikiCalculationResultViewModel GetViewModelForCaloriesCalculation(int? age, float? weight, float? height, int? percent, SexEnum sex, GoalEnum goal, ActivityRatioEnum activityRatio, int? proteinsPercent, int? fatsPercent, int? carbsPercent)
		{
			var viewModel = new WikiCalculationResultViewModel();
			viewModel.HarrisBenedictAns = (int)CalculateCaloriesViaHarrisBenedict(age.Value, weight.Value, height.Value, percent.Value, sex, goal, activityRatio);
			viewModel.MifflinStJeorAns = (int)CalculateCaloriesViaMifflinStJeor(age.Value, weight.Value, height.Value, percent.Value, sex, goal, activityRatio);
			viewModel.WhoAns = (int)CalculateCaloriesViaWho(age.Value, weight.Value, percent.Value, sex, goal, activityRatio);
			viewModel.AverageAns = (int)CalculateAverageCalories(viewModel.HarrisBenedictAns, viewModel.MifflinStJeorAns, viewModel.WhoAns);
			viewModel.GramsOfProteins = (int)CalculateGramsOfNutrients(viewModel.AverageAns, proteinsPercent.Value, fatsPercent.Value, carbsPercent.Value).gramsOfProteins;
			viewModel.GramsOfFats = (int)CalculateGramsOfNutrients(viewModel.AverageAns, proteinsPercent.Value, fatsPercent.Value, carbsPercent.Value).gramsOfFats;
			viewModel.GramsOfCarbs = (int)CalculateGramsOfNutrients(viewModel.AverageAns, proteinsPercent.Value, fatsPercent.Value, carbsPercent.Value).gramsOfCarbs;
			var user = _authService.GetUser();
			if (user == null)
			{
				return viewModel;
			}
			if (user.UserNutrients == null)
			{
				_wikiMCImgService.AddUserCalcultionResult(viewModel.AverageAns, viewModel.GramsOfProteins, viewModel.GramsOfFats, viewModel.GramsOfCarbs);
			}
			else
			{
				_wikiMCImgService.UpdateUserCalcultionResult(viewModel.AverageAns, viewModel.GramsOfProteins, viewModel.GramsOfFats, viewModel.GramsOfCarbs);
			}
			return viewModel;
		}

		public void AddUserCalcultionResult(int averageAns, int gramsOfProteins, int gramsOfCarbs, int gramsOfFats)
		{
			var user = _authService.GetUser();
			var dbWikiMcModel = new WikiCalculationResults()
			{
				AverageCalculatedCalories = averageAns,
				GramsProtein = gramsOfProteins,
				GramsCarb = gramsOfCarbs,
				GramsFat = gramsOfFats,
				CalculatorUser = user,
			};
			_wikiCalculationResultRepository.Add(dbWikiMcModel);
		}

		public void UpdateUserCalcultionResult(int averageAns, int gramsOfProteins, int gramsOfCarbs, int gramsOfFats)
		{
			var user = _authService.GetUser();
			var dbModel = user.UserNutrients;
			{
				dbModel.AverageCalculatedCalories = averageAns;
				dbModel.GramsProtein = gramsOfProteins;
				dbModel.GramsCarb = gramsOfCarbs;
				dbModel.GramsFat = gramsOfFats;
			};
			_wikiCalculationResultRepository.Update(dbModel);
		}
	}
}