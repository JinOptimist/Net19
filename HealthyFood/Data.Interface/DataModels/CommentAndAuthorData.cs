using Data.Interface.Models;
using Data.Sql.Models;

namespace Data.Interface.DataModels
{
    public class CommentAndAuthorData
    {
        public int CommentId { get; set; }

        public string Comment { get; set; }

        public User Author { get; set; }

        public PageWikiBlock Block { get; set; }
    }
}