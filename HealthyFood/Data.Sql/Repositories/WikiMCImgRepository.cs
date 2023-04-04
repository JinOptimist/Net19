using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class WikiMCImgRepository : IWikiMcRepository
	{
		private WebContext _webContext;

		public WikiMCImgRepository(WebContext webContext)
		{
			_webContext = webContext;
		}

		public void Add(WikiMcImage model)
		{
			_webContext.WikiMcImages.Add((WikiMcImage)model);
			_webContext.SaveChanges();
		}

		public WikiMcImage Get(int id)
		{
			return _webContext.WikiMcImages.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<WikiMcImage> GetAll()
		{
			return _webContext.WikiMcImages.ToList();
		}

		public IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type)
		{
			return _webContext.WikiMcImages.Where(x => x.ImgType == type);
		}

		public IEnumerable<WikiMcImage> GetAllImgByYear(int year)
		{
			return _webContext.WikiMcImages.Where(x => x.Year == year);
		}

		public void Remove(int id)
		{
			var mcImg = _webContext.WikiMcImages.FirstOrDefault(_x => _x.Id == id);
			_webContext.WikiMcImages.Remove(mcImg);
		}

		public void RemoveAllImgByType(ImgTypeEnum type)
		{
			var removedType = _webContext.WikiMcImages.Where(x => x.ImgType == type).ToList();
			removedType.ForEach(x => _webContext.WikiMcImages.Remove(x));
		}

		public void RemoveAllImgByYear(int year)
		{
			var removedYear = _webContext.WikiMcImages.Where(x => x.Year == year).ToList();
			removedYear.ForEach(x => _webContext.WikiMcImages.Remove(x));
		}
	}
}
