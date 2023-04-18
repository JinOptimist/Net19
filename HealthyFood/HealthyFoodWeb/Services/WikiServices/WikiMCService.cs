using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiMCService : IWikiMCService
    {
        public const int CURRENT_YEAR = 2023;

        private IWikiMcRepository _wikiMCRepository;

        public WikiMCService(IWikiMcRepository wikiMCRepository)
        {
            _wikiMCRepository = wikiMCRepository;
        }

        public void AddImg(WikiMCViewModel viewModel)
        {
            var WikiMc = new WikiMcImage()
            {
                ImgType = viewModel.ImgType,
                ImgUrl = viewModel.ImgPath,
                Year = viewModel.Year,
                //Tags = viewModel.Tags,
            };
            _wikiMCRepository.Add(WikiMc);
        }

        public IEnumerable<WikiMcImage> GetAllImgByYear()
        {
            return _wikiMCRepository.GetAllImgByYearWithTags(CURRENT_YEAR);
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

		//public IEnumerable<WikiMcImage> GetAllUserImages(User currentUser)
		//{
		//	return _wikiMCRepository
  //              .GetImagesWithUploader()
  //              .Where(x => x.ImageUploader == currentUser)
  //              .ToList ();
		//}

        //public IEnumerable<WikiMcImage> GetAllUserImages()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
