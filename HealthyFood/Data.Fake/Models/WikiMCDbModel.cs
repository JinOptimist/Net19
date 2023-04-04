using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class WikiMCDbModel :BaseDbModel, IWikiMCDbModel
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeEnum ImgType { get; set; }
    }
}
