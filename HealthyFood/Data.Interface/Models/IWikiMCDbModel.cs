using Data.Fake.Models;

namespace Data.Interface.Models
{
    public interface IWikiMCDbModel : IDbModel
    {
        public int Year { get; set; }
        public string ImgUrl { get; set; }
        public ImgTypeModel ImgType { get; set; }
    }
}
