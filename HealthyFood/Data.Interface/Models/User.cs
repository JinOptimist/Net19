using Data.Sql.Models;

namespace Data.Interface.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public string Password { get; set; }

        public virtual List<Game> CreatedGames { get; set; }

        public virtual List<PageWikiBlock> Blocks { get; set;}

        public virtual List<WikiMcImage> UploadedImages { get; set; }
    }

        public string Password { get; set; }

        public virtual List<WikiBlockComment> Comments { get; set; }

        public virtual List<Game> CreatedGames { get; set; }

        public virtual List<PageWikiBlock> Blocks { get; set;}
        
	}
}
