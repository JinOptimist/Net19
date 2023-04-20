namespace HealthyFoodWeb.Models.ScreensViewModels
{
    public class GameAndScreenViewModel
    {
        public string GameName { get; set; }
        public string GameCoverUrl { get; set; }
        public List<ScreenAndAuthorViewModel> Screens { get; set; }
    }
}
