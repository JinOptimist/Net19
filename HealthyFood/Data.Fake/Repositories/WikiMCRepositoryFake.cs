using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Fake.Models;

namespace Data.Fake.Repositories
{
    public class WikiMCRepositoryFake : BaseRepository<IWikiMCDbModel>, IWikiMCRepository
    {
        public WikiMCRepositoryFake()
        {
            FakeDbModels = new List<IWikiMCDbModel>() {
                new WikiMCDbModel{
                    Id = 1,
                    ImgUrl = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    Type = "proteins"},
                new WikiMCDbModel{
                    Id = 2,
                    ImgUrl = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    Type = "fats"},
                new WikiMCDbModel{
                    Id = 3,
                    ImgUrl = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    Type = "carbs"},
                new WikiMCDbModel{
                    Id = 4,
                    ImgUrl = "https://scitechdaily.com/images/Foods-Rich-in-Protein.jpg",
                    Year = 2023,
                    Type = "proteins"},
                new WikiMCDbModel{
                    Id = 5,
                    ImgUrl = "https://www.doctorkiltz.com/wp-content/uploads/2021/04/Fats.jpg",
                    Year = 2023,
                    Type = "fats"},
                new WikiMCDbModel{
                    Id = 6,
                    ImgUrl = "https://www.doctorkiltz.com/wp-content/uploads/2021/02/AdobeStock_211695579-scaled.jpeg",
                    Year = 2023,
                    Type = "carbs" },
                 };
        }

        public IEnumerable<IWikiMCDbModel> GetAllImgByYear(int year)
        {
            return FakeDbModels.Where(x => x.Year == year);
        }

        public IEnumerable<IWikiMCDbModel> GetAllImgByType(string type)
        {
            return FakeDbModels.Where(x => x.Type == type);
        }

        public void RemoveAllImgByType(string type)
        {
            var removedType = FakeDbModels.Where(x => x.Type == type).ToList();
            removedType.ForEach(x => FakeDbModels.Remove(x));
        }

        public void RemoveAllImgByYear(int year)
        {
            var removedYear = FakeDbModels.Where(x => x.Year == year).ToList();
            removedYear.ForEach(x => FakeDbModels.Remove(x));
        }
    }
}
