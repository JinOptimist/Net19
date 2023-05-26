using Data.Interface.DataModels;
using Data.Interface.Models;
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
        public const int CURRENT_YEAR = 2023;

        private IWikiMcRepository _wikiMcRepository;
        private IWikiTagRepository _tagRepository;
        private IAuthService _authService;
        private IPagginatorService _paginatorService;

        public WikiMCService(IWikiMcRepository wikiMCRepository, IAuthService authService, IWikiTagRepository tagService, IPagginatorService paginatorService)
        {
            _wikiMcRepository = wikiMCRepository;
            _authService = authService;
            _tagRepository = tagService;
            _paginatorService = paginatorService;
        }

        public void AddImg(WikiMcViewModel viewModel)
        {

            var user = _authService.GetUser();
            var WikiMc = new WikiMcImage()
            {
                ImgType = viewModel.ImgType,
                ImgUrl = viewModel.ImgPath,
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

                WikiMc.Tags.Add(dbTag);
            }

            _wikiMcRepository.Add(WikiMc);
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

        public void RemoveByType(ImgTypeEnum type)
        {
            _wikiMcRepository.RemoveAllImgByType(type);
        }

        public void RemoveByYear(int year)
        {
            _wikiMcRepository.RemoveAllImgByYear(year);
        }

        public IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
        {
            return _wikiMcRepository.GetUserImages();
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
                ImgPath = imageDb.ImgUrl,
                Year = imageDb.Year,
                UserTags = imageDb.Tags.Select(x => x.TagName).ToList()
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
				ImgPath = x.ImgUrl,
				ImgType = x.ImgType,
				UserTags = x.Tags?.Select(x => x.TagName).ToList() ?? new List<string>()
			};
		}

		public ShowUploadedImagesViewModel GetShowUploadedImagesViewModel(int page, int perPage)
		{
            var viewModel = new ShowUploadedImagesViewModel();

			viewModel.PaginatorViewModel = _paginatorService
				.GetPaginatorViewModel(
					page,
					perPage,
					BuildWikiMcViewModelFromDbModel,
					_wikiMcRepository);

			return viewModel;
		}
	}
}

