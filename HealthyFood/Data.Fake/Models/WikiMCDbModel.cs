using Data.Interface.Models;
using static Data.Interface.Models.IWikiMCDbModel;

namespace Data.Fake.Models
{
    public class WikiMCDbModel :BaseDbModel, IWikiMCDbModel
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeModel ImgType { get; set; }
    }
}
