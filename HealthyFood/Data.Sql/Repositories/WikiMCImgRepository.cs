using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Data.Sql.Repositories
{
    public class WikiMCImgRepository : BaseRepository<WikiMcImage>, IWikiMcRepository
    {
        public WikiMCImgRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<ImagesAndInfoAboutTheirUploaderData> GetUserImagesIQueryable()
            => _dbSet
                .Select(image => new ImagesAndInfoAboutTheirUploaderData
                {
                    Year = image.Year,
                    ImgUrl = image.ImgUrl,
                    ImgType = image.ImgType,
                    UserName = image.ImageUploader.Name,
                    Tags = image.ImageUploader.UploadedImages.SelectMany(x => x.Tags).Select(x => x.TagName).Distinct().ToList(),
                });

        public List<ImagesAndInfoAboutTheirUploaderData> GetUserImages()
        {
            return GetUserImagesIQueryable().ToList();
        }

        public ImagesAndPaginatorData GetImagesForPaginator(int page, int perPage)
        {
            var dataModel = new ImagesAndPaginatorData();
            var images =
                GetUserImagesIQueryable()
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();
            dataModel.Images = images;
            dataModel.TotalCount = _dbSet.Count();
            return dataModel;
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
    }
}
