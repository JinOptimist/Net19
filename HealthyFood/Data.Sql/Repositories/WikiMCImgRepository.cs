using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class WikiMCImgRepository : BaseRepository<WikiMcImage>, IWikiMcRepository
	{
		
		public WikiMCImgRepository(WebContext webContext) : base(webContext)
		{
			
		}

		
		public IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type)
		{
			return _dbSet.Where(x => x.ImgType == type);
		}

		public IEnumerable<WikiMcImage> GetAllImgByYear(int year)
		{
			return _dbSet.Where(x => x.Year == year);
		}


		public void RemoveAllImgByType(ImgTypeEnum type)
		{
			var removedType = _dbSet.Where(x => x.ImgType == type).ToList();
			removedType.ForEach(x => _dbSet.Remove(x));
		}

		public void RemoveAllImgByYear(int year)
		{
			var removedYear = _dbSet.Where(x => x.Year == year).ToList();
			removedYear.ForEach(x => _dbSet.Remove(x));
		}
	}
}
