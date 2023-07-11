using Data.Interface.Models.WikiMc;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class WikiMcViewModel
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
		public IFormFile ImageCover { get; set; }
		public ImgTypeEnum ImgType { get; set; }
        public int Year { get; set; }
        public string EnteredTags { get; set; }
        public List<string> UserTags { get; set; } = new List<string>();
    }
}
