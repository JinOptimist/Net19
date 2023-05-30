using Data.Sql.Models;

namespace Data.Interface.Models
{
    public class WikiBlockImg : BaseModel
    {
        public string Url { get; set; }

        public virtual PageWikiBlock WikiBlock { get; set; }
    }
}
