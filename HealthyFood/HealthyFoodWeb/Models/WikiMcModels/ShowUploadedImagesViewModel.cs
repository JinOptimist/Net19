using Data.Interface.Models.WikiMc;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class ShowUploadedImagesViewModel
	{
		public PagginatorViewModel<WikiMcViewModel> PaginatorViewModel { get; set; }
		public WikiMcViewModel Image { get; set; }
	}
}
