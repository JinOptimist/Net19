using Data.Interface.Models.WikiMc;
using HealthyFoodWeb.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class WikiMcViewModel
    {
        public int Id { get; set; }

        [Required]
        [MyUrl]
        public string ImgPath { get; set; }

        public ImgTypeEnum ImgType { get; set; }
        public int Year { get; set; }
        public string EnteredTags { get; set; }
        public List<string> UserTags { get; set; } = new List<string>();
    }
}
