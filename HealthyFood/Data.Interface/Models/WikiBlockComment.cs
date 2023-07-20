using Data.Sql.Models;

namespace Data.Interface.Models
{
    public class WikiBlockComment : BaseModel
    {
        public string Text { get; set; }

        public virtual User Author { get; set; }

        public virtual PageWikiBlock Block { get; set; }
    }
}
