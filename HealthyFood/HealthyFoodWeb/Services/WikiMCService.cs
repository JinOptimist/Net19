using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public class WikiMCService : IWikiMCService
    {
        public const int CURRENT_YEAR = 2023;
        public const string CURRENT_TYPE = "proteins";

        private IWikiMCRepository _wikiMCRepository;

        public WikiMCService(IWikiMCRepository wikiMCRepository)
        {
            _wikiMCRepository = wikiMCRepository;
        }

        public void AddImg(WikiMCViewModel viewModel)
        {
            var dbWikiMCImg = new WikiMCModel()
            {
                Type = viewModel.Type,
                Path = viewModel.ImgPath,
                Year = viewModel.Year,
            };

            _wikiMCRepository.SaveImg(dbWikiMCImg);
        }

        public List<IWikiMCModel> GetAllImgByYear()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.Year == CURRENT_YEAR).
                ToList();
        }
      
        public List<IWikiMCModel> GetAllImgByType()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.Type == CURRENT_TYPE)
                .ToList();
        }

        public void RemoveByType(string type)
        {
            _wikiMCRepository.RemoveByType(type);
        }

        public void RemoveByYear(int year)
        {
            _wikiMCRepository.RemoveByYear(year);
        }
    }
}
