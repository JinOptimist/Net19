using Data.Interface.Models;

namespace HealthyFoodWeb.Models
{
    public class WikiMCViewModel
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public ImgTypeEnum ImgType { get; set; }
        public int Year { get; set; }
		public List<string> Tags { get; set; } = new List<string>();
	}
}
