using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Data.Fake.Models;

namespace HealthyFoodWeb.Services
{
    public class WikiMCService : IWikiMCService
    {
        public const int CURRENT_YEAR = 2023;

        private IWikiMCRepository _wikiMCRepository;

        public WikiMCService(IWikiMCRepository wikiMCRepository)
        {
            _wikiMCRepository = wikiMCRepository;
        }

        public void AddImg(WikiMCViewModel viewModel)
        {
            var wikiMCDbModel = new WikiMCDbModel()
            {
                ImgType = viewModel.ImgType,
                ImgUrl = viewModel.ImgPath,
                Year = viewModel.Year,
            };
            _wikiMCRepository.Add(wikiMCDbModel);
        }

        public IEnumerable<IWikiMCDbModel> GetAllImgByYear()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.Year == CURRENT_YEAR).
                ToList();
        }
      
        public IEnumerable<IWikiMCDbModel> GetAllImgByType()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.ImgType == ImgTypeDbModel.proteins)
                .ToList();
        }

        public void RemoveByType(ImgTypeDbModel type)
        {
            _wikiMCRepository.RemoveAllImgByType(type);
        }

        public void RemoveByYear(int year)
        {
            _wikiMCRepository.RemoveAllImgByYear(year);
        }
    }
}
