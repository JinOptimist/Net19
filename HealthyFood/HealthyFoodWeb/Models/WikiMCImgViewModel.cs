namespace HealthyFoodWeb.Models
{
    public class WikiMCImgViewModel
    {
        public List<WikiMCViewModel> AllImgByYear { get; set; }
        public List<WikiMCViewModel> AllImgByType { get; set; }
		public WikiMCViewModel GetTag { get; set; }
	}
}