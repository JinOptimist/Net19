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

        public List<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
        {
            return _dbSet
                .Select(image => new ImagesAndInfoAboutTheirUploaderData
                {
                    Year = image.Year,
                    ImgUrl = image.ImgUrl,
                    ImgType = image.ImgType,
                    UserName = image.ImageUploader.Name,
                    Tags = image.ImageUploader.UploadedImages.SelectMany(x => x.Tags).Select(x => x.TagName).Distinct().ToList(),
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
