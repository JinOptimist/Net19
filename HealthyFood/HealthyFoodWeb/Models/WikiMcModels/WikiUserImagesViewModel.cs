using Data.Interface.Models.WikiMc;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class WikiUserImagesViewModel
    {
        public List<WikiMcViewModel> UserImages { get; set; }
        public int ActivePageNumber { get; set; }
        public List<int> PageList { get; set; }
        public ImgTypeEnum ImgType { get; set; }
    }
}
