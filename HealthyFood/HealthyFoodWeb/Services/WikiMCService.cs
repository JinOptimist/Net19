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
        public const string CURRENT_TYPE = "proteins";

        private IWikiMCRepository _wikiMCRepository;

        public WikiMCService(IWikiMCRepository wikiMCRepository)
        {
            _wikiMCRepository = wikiMCRepository;
        }

        public void AddImg(WikiMCViewModel viewModel)
        {
            var wikiMCDbModel = new WikiMCDbModel()
            {
                Type = viewModel.Type,
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
                .Where(x => x.Type == CURRENT_TYPE)
                .ToList();
        }

        public void RemoveByType(string type)
        {
            _wikiMCRepository.RemoveAllImgByType(type);
        }

        public void RemoveByYear(int year)
        {
            _wikiMCRepository.RemoveAllImgByYear(year);
        }
    }
}
