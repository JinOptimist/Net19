using Data.Interface.Models;

namespace HealthyFoodWeb.Models
{
	public class WikiUserImagesViewModel
	{
		public List<WikiMcViewModel> UserImages { get; set; }
        public int ActivePageNumber { get; set; }
        public List<int> PageList { get; set; }
        public ImgTypeEnum ImgType { get; set; }
    }
}
