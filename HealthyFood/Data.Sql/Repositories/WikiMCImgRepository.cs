using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class WikiMCImgRepository : BaseRepository<WikiMcImage>, IWikiMcRepository
	{
        public WikiMCImgRepository(WebContext webContext) : base(webContext) { }

        public List<ImagesAndInfoAboutTheirUploader> GetUserImages()
        {
            return _dbSet
                .Select(image => new ImagesAndInfoAboutTheirUploader
                {
                    Year = image.Year,
                    ImgUrl = image.TextReview,
                    UserName = image.ImageUploader.Name,
                    GamesName = image.User.CreatedGames.Select(x => x.Name).ToList(),

                }).ToList();

        }

        public IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type)
		{
			return _dbSet.Where(x => x.ImgType == type);
		}

		public IEnumerable<WikiMcImage> GetAllImgByYear(int year)
		{
			return _dbSet.Where(x => x.Year == year);
		}

		public IEnumerable<WikiMcImage> GetAllImgByYearWithTags(int year)
		{
			return _dbSet
				.Include(x => x.Tags)
				.Where(x => x.Year == year)
				.ToList();
		}

		public IEnumerable<WikiMcImage> GetImagesByUserId(int userId)
		{
			return _dbSet.Where(x => x.ImageUploader.Id == userId).ToList();
		}

		public void RemoveAllImgByType(ImgTypeEnum type)
		{
			var removedType = _dbSet.Where(x => x.ImgType == type).ToList();
			removedType.ForEach(x => _dbSet.Remove(x));
            _webContext.SaveChanges();
        }

		public void RemoveAllImgByYear(int year)
		{
			var removedYear = _dbSet.Where(x => x.Year == year).ToList();
			removedYear.ForEach(x => _dbSet.Remove(x));
            _webContext.SaveChanges();
        }
	}
}
