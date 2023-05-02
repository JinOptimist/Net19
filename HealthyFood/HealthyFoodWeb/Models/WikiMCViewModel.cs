using Data.Interface.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models
{
    public class WikiMcViewModel
    {
        [Required]
        [Url]
        public string ImgPath { get; set; }

        public ImgTypeEnum ImgType { get; set; }
        public int Year { get; set; }
        public string EnteredTags { get; set; }
		public List<string> UserTags { get; set; } = new List<string>();
	}
}
