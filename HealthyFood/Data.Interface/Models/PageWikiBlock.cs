using Data.Interface.Models;

namespace Data.Sql.Models
{
	public class PageWikiBlock : BaseModel
	{
		public string Title { get; set; }

		public string Text { get; set; }

		public virtual User Author { get; set; }

        public virtual List<WikiBlockComment> Comment { get; set; }

		public virtual List<WikiBlockImg> UrlImg { get; set; }
    }
}
