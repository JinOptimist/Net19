using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class WikiMCService : IWikiMcService
    {
        public const int CURRENT_YEAR = 2023;

        private IWikiMcRepository _wikiMCRepository;
        private IWikiTagRepository _tagRepository;
        private IAuthService _authService;

        public WikiMCService(IWikiMcRepository wikiMCRepository, IAuthService authService, IWikiTagRepository tagService)
        {
            _wikiMCRepository = wikiMCRepository;
            _authService = authService;
            _tagRepository = tagService;
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
            };

            var tags = viewModel.EnteredTags.Split(',').ToList();
            foreach (var tag in tags)
            {
                var dbTag = _tagRepository.GetOrCreateTag(tag);
                WikiMc.Tags.Add(dbTag);
            }

            _wikiMCRepository.Add(WikiMc);
        }

        public IEnumerable<WikiMcImage> GetAllImgByYear()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.Year == CURRENT_YEAR).
                ToList();
        }

        public IEnumerable<WikiMcImage> GetAllImgByType()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.ImgType == ImgTypeEnum.Proteins)
                .ToList();
        }

        public void RemoveByType(ImgTypeEnum type)
        {
            _wikiMCRepository.RemoveAllImgByType(type);
        }

        public void RemoveByYear(int year)
        {
            _wikiMCRepository.RemoveAllImgByYear(year);
        }

        public IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
        {
            return _wikiMCRepository.GetUserImages();
        }

        public ImagesAndPaginatorData GetImagesForPaginator(int page, int perPage)
        {
            return _wikiMCRepository
                .GetImagesForPaginator(page, perPage);
        }

        public WikiMcViewModel GetImageViewModel(int id)
        {
            var imageDb = _wikiMCRepository.GetImageAndTags(id);
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
                AvailableTags = tags,
                UserTags = imageDb.Tags.Select(x => x.TagName).ToList()
            };
        }

        public void UpdateAllExeptTags(int id, ImgTypeEnum type, string imgUrl, int year)
        {
            _wikiMCRepository.UpdateAllExeptTags(id, type, imgUrl, year);
        }

        public void UpdateTags(int id, List<string> tags)
        {
            var image = _gameRepository.GetGameAndGenres(id);
            if (image.Genres == null)
            {
                image.Genres = new List<GameCategory>();
            }

            var newGenres = _gameCategoryRepository
                .GetAll()
                .Where(genre => newGenresNames.Contains(genre.Name))
                .ToList();

            image.Genres.RemoveAll(x => true);

            newGenres.ForEach(genre => image.Genres.Add(genre));
            // newGenres.ForEach(game.Genres.Add);

            _gameRepository.Update(image);
        }
    }
}

