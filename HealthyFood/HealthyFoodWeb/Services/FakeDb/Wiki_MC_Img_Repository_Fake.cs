using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services.FakeDb
{
    public class Wiki_MC_Img_Repository_Fake : IWiki_MC_Img_Repository
    {
        public static List<IWiki_MC_Img_Model> FakeDbWikiMCImg =
             new List<IWiki_MC_Img_Model>() {
                new Wiki_MC_Img_Model()
                {
                    Id = 1,
                    Path = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    Type = "proteins"},
                new Wiki_MC_Img_Model()
                {
                    Id = 2,
                    Path = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    Type = "fats"},
                new Wiki_MC_Img_Model()
                {
                    Id = 3,
                    Path = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    Type = "carbs"},
                new Wiki_MC_Img_Model()
                {
                    Id = 4,
                    Path = "https://scitechdaily.com/images/Foods-Rich-in-Protein.jpg",
                    Year = 2022,
                    Type = "proteins"},
                new Wiki_MC_Img_Model()
                {
                    Id = 5,
                    Path = "https://www.doctorkiltz.com/wp-content/uploads/2021/04/Fats.jpg",
                    Year = 2022,
                    Type = "fats"},
                new Wiki_MC_Img_Model()
                {
                    Id = 6,
                    Path = "https://www.doctorkiltz.com/wp-content/uploads/2021/02/AdobeStock_211695579-scaled.jpeg",
                    Year = 2022,
                    Type = "carbs"},
             };

        public List<IWiki_MC_Img_Model> GetAll()
        {
            return FakeDbWikiMCImg;
        }

        public IWiki_MC_Img_Model GetImgByYear(int year)
        {
            return (IWiki_MC_Img_Model)FakeDbWikiMCImg.Where(x => x.Year == year);
        }

        public IWiki_MC_Img_Model GetImgByType(string type)
        {
            return (IWiki_MC_Img_Model)FakeDbWikiMCImg.Where(x => x.Type == type);
        }

        public void RemoveByType(string type)
        {
            FakeDbWikiMCImg.Remove(GetImgByType(type));
        }

        public void RemoveByYear(int year)
        {
            FakeDbWikiMCImg.Remove(GetImgByYear(year));
        }

        public void SaveImg(IWiki_MC_Img_Model img)
        {
            var maxExistedId = FakeDbWikiMCImg.Max(x => x.Id);
            img.Id = maxExistedId + 1;
            FakeDbWikiMCImg.Add(img);
        }
    }
}
