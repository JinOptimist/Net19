using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Fake.Repositories
{
    public class WikiMCRepositoryFake : BaseRepository<WikiMcImage>, IWikiMcRepository
    {
        public WikiMCRepositoryFake()
        {
            FakeDbModels = new List<WikiMcImage>() {
                new WikiMcImage{
                    Id = 1,
                    ImgUrl = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Proteins},
                new WikiMcImage{
                    Id = 2,
                    ImgUrl = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Fats},
                new WikiMcImage{
                    Id = 3,
                    ImgUrl = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Carbs},
                new WikiMcImage{
                    Id = 4,
                    ImgUrl = "https://scitechdaily.com/images/Foods-Rich-in-Protein.jpg",
                    Year = 2022,
                    ImgType = ImgTypeEnum.Proteins},
                new WikiMcImage{
                    Id = 5,
                    ImgUrl = "https://www.doctorkiltz.com/wp-content/uploads/2021/04/Fats.jpg",
                    Year = 2022,
                    ImgType = ImgTypeEnum.Fats},
                new WikiMcImage{
                    Id = 6,
                    ImgUrl = "https://www.doctorkiltz.com/wp-content/uploads/2021/02/AdobeStock_211695579-scaled.jpeg",
                    Year = 2022,
                    ImgType = ImgTypeEnum.Carbs },
                 };
        }

        public IEnumerable<WikiMcImage> GetAllImgByYear(int year)
        {
            return FakeDbModels.Where(x => x.Year == year);
        }

        public IEnumerable<WikiMcImage> GetAllImgByType(ImgTypeEnum type)
        {
            return FakeDbModels.Where(x => x.ImgType == type);
        }

        public void RemoveAllImgByType(ImgTypeEnum type)
        {
            var removedType = FakeDbModels.Where(x => x.ImgType == type).ToList();
            removedType.ForEach(x => FakeDbModels.Remove(x));
        }

        public void RemoveAllImgByYear(int year)
        {
            var removedYear = FakeDbModels.Where(x => x.Year == year).ToList();
            removedYear.ForEach(x => FakeDbModels.Remove(x));
        }

        public IEnumerable<WikiMcImage> GetAllImageWithTags()
        {
			throw new NotImplementedException();
		}
    }
}
