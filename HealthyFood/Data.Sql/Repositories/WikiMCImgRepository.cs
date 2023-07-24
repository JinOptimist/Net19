using Data.Interface.DataModels;
using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class WikiMCImgRepository : BaseRepository<WikiMcImage>, IWikiMcRepository
    {
        public WikiMCImgRepository(WebContext webContext) : base(webContext) { }

        private IQueryable<ImagesAndInfoAboutTheirUploaderData> GetUserImagesIQueryable()
            => _dbSet
                .Select(image => new ImagesAndInfoAboutTheirUploaderData
                {
                    Id = image.Id,
                    Year = image.Year,
                    ImgUrl = image.ImgUrl,
                    ImgType = image.ImgType,
                    UserName = image.ImageUploader.Name,
                    Tags = image.Tags.Select(x => x.TagName).Distinct().ToList(),
                });

        public List<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
        {
            return GetUserImagesIQueryable().ToList();
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

        public void DeleteImgByType(ImgTypeEnum type)
        {
            var removedType = _dbSet.Where(x => x.ImgType == type).ToList();
            removedType.ForEach(x => _dbSet.Remove(x));
            _webContext.SaveChanges();
        }

        public void DeleteImgByYear(int year)
        {
            var removedYear = _dbSet.Where(x => x.Year == year).ToList();
            removedYear.ForEach(x => _dbSet.Remove(x));
            _webContext.SaveChanges();
        }

		public void DeleteImage(int imgId)
		{
            var image = _dbSet.Single(x => x.Id == imgId);
            _dbSet.Remove(image);
			_webContext.SaveChanges();
		}

		public WikiMcImage GetImageAndTags(int id)
        {
            return _dbSet
                .Include(x => x.Tags)
                .SingleOrDefault(x => x.Id == id);
        }

        public void UpdateAllExeptTags(int id, ImgTypeEnum type, string imgUrl, int year)
        {
            var image = Get(id);
            image.ImgType = type;
            image.ImgUrl = imgUrl;
            image.Year = year;
            _webContext.SaveChanges();
        }

		public ImagesCountData GetDataForImagesCount(int? year, string tag, ImgTypeEnum type)
		{
            IQueryable<WikiMcImage> availableImages = _dbSet;
            if (year != null)
            {
				availableImages = availableImages.Where(x => x.Year == year);
            }
            if (tag != null)
            {
				availableImages = availableImages.Where(dbImage => dbImage.Tags.Any(dbTag => dbTag.TagName == tag));
            }
            if(type != ImgTypeEnum.None)
            {
				availableImages = availableImages.Where(x => x.ImgType == type);
			}
            var count = availableImages.Count();
            var urls = availableImages
                .Select(x => x.ImgUrl)
                .ToList();

            return new ImagesCountData
			{
				Count = count,
				ImagesUrl = urls
			};
		}

		public override PaginatorData<WikiMcImage> GetPaginator(int page, int perPage)
		{
			var initialSource = _dbSet.Include(x => x.Tags);
			return base.GetPaginator(initialSource, page, perPage);
		}
	}
}
