namespace Data.Interface.Models.WikiMc
{
    public class WikiMcImage : BaseModel
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeEnum ImgType { get; set; }

        public virtual List<WikiTags> Tags { get; set; }

        public virtual User ImageUploader { get; set; }
    }
}
