using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

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
                .Where(x => x.ImgType == ImgTypeEnum.proteins)
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
    }
}
