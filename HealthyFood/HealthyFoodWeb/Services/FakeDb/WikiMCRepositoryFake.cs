using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services.FakeDb
{
    public class WikiMCRepositoryFake : IWikiMCRepository
    {
        public static List<IWikiMCModel> FakeDbWikiMCImg =
             new List<IWikiMCModel>() {
                new WikiMCModel()
                {
                    Id = 1,
                    Path = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    Type = "proteins"},
                new WikiMCModel()
                {
                    Id = 2,
                    Path = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    Type = "fats"},
                new WikiMCModel()
                {
                    Id = 3,
                    Path = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    Type = "carbs"},
                new WikiMCModel()
                {
                    Id = 4,
                    Path = "https://scitechdaily.com/images/Foods-Rich-in-Protein.jpg",
                    Year = 2022,
                    Type = "proteins"},
                new WikiMCModel()
                {
                    Id = 5,
                    Path = "https://www.doctorkiltz.com/wp-content/uploads/2021/04/Fats.jpg",
                    Year = 2022,
                    Type = "fats"},
                new WikiMCModel()
                {
                    Id = 6,
                    Path = "https://www.doctorkiltz.com/wp-content/uploads/2021/02/AdobeStock_211695579-scaled.jpeg",
                    Year = 2022,
                    Type = "carbs"},
             };

        public List<IWikiMCModel> GetAll()
        {
            return FakeDbWikiMCImg;
        }

        public IWikiMCModel GetImgByYear(int year)
        {
            return (IWikiMCModel)FakeDbWikiMCImg.Where(x => x.Year == year);
        }

        public IWikiMCModel GetImgByType(string type)
        {
            return (IWikiMCModel)FakeDbWikiMCImg.Where(x => x.Type == type);
        }

        public void RemoveByType(string type)
        {
            FakeDbWikiMCImg.Remove(GetImgByType(type));
        }

        public void RemoveByYear(int year)
        {
            FakeDbWikiMCImg.Remove(GetImgByYear(year));
        }

        public void SaveImg(IWikiMCModel img)
        {
            var maxExistedId = FakeDbWikiMCImg.Max(x => x.Id);
            img.Id = maxExistedId + 1;
            FakeDbWikiMCImg.Add(img);
        }
    }
}
