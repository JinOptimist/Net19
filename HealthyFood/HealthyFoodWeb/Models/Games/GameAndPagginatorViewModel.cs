namespace HealthyFoodWeb.Models.Games
{
    public class GameAndPagginatorViewModel
    {
        public List<GameViewModel> Games { get; set; }
        public int ActivePageNumber { get; set; }
        public List<int> PageList { get; set; }
    }
}
