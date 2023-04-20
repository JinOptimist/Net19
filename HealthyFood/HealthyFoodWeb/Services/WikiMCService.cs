using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class WikiMCService : IWikiMCService
    {
        public const int CURRENT_YEAR = 2023;

        private IWikiMcRepository _wikiMCRepository;
		private IAuthService _authService;

		public WikiMCService(IWikiMcRepository wikiMCRepository, IAuthService authService)
        {
            _wikiMCRepository = wikiMCRepository;
			_authService = authService;
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

		public IEnumerable<ImagesAndInfoAboutTheirUploader> GetUserImages()
		{
			return _wikiMCRepository.GetUserImages();
		}
	}
}
