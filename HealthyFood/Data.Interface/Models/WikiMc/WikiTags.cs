namespace Data.Interface.Models.WikiMc
{
    public class WikiTags : BaseModel
    {
        public string TagName { get; set; }

        public virtual List<WikiMcImage> Images { get; set; }
    }
}