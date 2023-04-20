namespace Data.Interface.Models
{
    public class WikiMcImage : BaseModel
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeEnum ImgType { get; set; }

        public string EnteredTags { get; set; }

        public List<string> UserTags { get; set; }

        public virtual List<WikiTags> Tags { get; set; }

        public virtual User ImageUploader { get; set; }
	}
}
