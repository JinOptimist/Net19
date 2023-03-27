using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models.WikiModels;

namespace HealthyFoodWeb.Services
{
    public class WikiMCImgService : IWikiMCImgService
    {
        public const int CURRENT_YEAR = 2023;
        public const string CURRENT_TYPE = "proteins";

        private IWiki_MC_Img_Repository _wikiMCRepository;

        public WikiMCImgService(IWiki_MC_Img_Repository wikiMCRepository)
        {
            _wikiMCRepository = wikiMCRepository;
        }

        public void AddImg(MacronutrientCalculatorIMGViewModel viewModel)
        {
            var dbWikiMCImg = new Wiki_MC_Img_Model()
            {
                Type = viewModel.Type,
                Path = viewModel.Path,
                Year = viewModel.Year,
            };

            _wikiMCRepository.SaveImg(dbWikiMCImg);
        }

        public List<IWiki_MC_Img_Model> GetAllImgByYear()
        {
            return _wikiMCRepository
                .GetAll()
                .Where(x => x.Year == CURRENT_YEAR).
                ToList();
        }
      
        public List<IWiki_MC_Img_Model> GetAllImgByType()
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
