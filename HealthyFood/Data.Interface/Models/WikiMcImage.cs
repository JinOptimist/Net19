namespace Data.Interface.Models
{
    public class WikiMcImage : BaseModel
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeEnum ImgType { get; set; }
    }
}
