using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
	public class WikiMCImgRepository : IWikiMCRepository
	{
		private WebContext _webContext;

		public WikiMCImgRepository(WebContext webContext)
		{
			_webContext = webContext;
		}

		public void Add(IWikiMCDbModel model)
		{
			_webContext.MacronutrientCalculatorImgs.Add((WikiMCDbModel)model);
			_webContext.SaveChanges();
		}

		public IWikiMCDbModel Get(int id)
		{
			return _webContext.MacronutrientCalculatorImgs.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<IWikiMCDbModel> GetAll()
		{
			return _webContext.MacronutrientCalculatorImgs.ToList();
		}

		public IEnumerable<IWikiMCDbModel> GetAllImgByType(ImgTypeEnum type)
		{
			return _webContext.MacronutrientCalculatorImgs.Where(x => x.ImgType == type);
		}

		public IEnumerable<IWikiMCDbModel> GetAllImgByYear(int year)
		{
			return _webContext.MacronutrientCalculatorImgs.Where(x => x.Year == year);
		}

		public void Remove(int id)
		{
			var mcImg = _webContext.MacronutrientCalculatorImgs.FirstOrDefault(_x => _x.Id == id);
			_webContext.MacronutrientCalculatorImgs.Remove(mcImg);
		}

		public void RemoveAllImgByType(ImgTypeEnum type)
		{
			var removedType = _webContext.MacronutrientCalculatorImgs.Where(x => x.ImgType == type).ToList();
			removedType.ForEach(x => _webContext.MacronutrientCalculatorImgs.Remove(x));
		}

		public void RemoveAllImgByYear(int year)
		{
			var removedYear = _webContext.MacronutrientCalculatorImgs.Where(x => x.Year == year).ToList();
			removedYear.ForEach(x => _webContext.MacronutrientCalculatorImgs.Remove(x));
		}
	}
}
