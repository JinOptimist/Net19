using Data.Interface.Models;

namespace HealthyFoodWeb.Models.WikiMcModels
{
	public class ShowUploadedImagesViewModel
	{
		public PagginatorViewModel<WikiMcViewModel> PaginatorViewModel { get; set; }
		public ImgTypeEnum ImgType { get; set; }
	}
}
