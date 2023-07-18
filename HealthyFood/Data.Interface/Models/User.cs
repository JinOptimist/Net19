using Data.Interface.Models.WikiMc;
using Data.Sql.Models;
namespace Data.Interface.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public string Password { get; set; }

        public MyRole Role { get; set; }

        public virtual List<WikiBlockComment> Comments { get; set; }

        public virtual List<Game> CreatedGames { get; set; }

        public virtual List<PageWikiBlock> Blocks { get; set; }

        public virtual List<Cart> Products { get; set; }

        public virtual List<StoreItem> StoreItems { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<WikiMcImage> UploadedImages { get; set; }

        public virtual WikiCalculationResults UserNutrients { get; set; }
	}
}
