namespace Data.Interface.Models
{
    public interface IWikiMCDbModel : IDbModel
    {
        public int Year { get; set; }
        public string ImgUrl { get; set; }
        public ImgTypeEnum ImgType { get; set; }
    }
}
