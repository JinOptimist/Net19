namespace HealthyFoodWeb.Models
{
    public class GameViewModel
    {
        public string Name { get; set; }
        public string CoverUrl { get; set; }
        public decimal Price { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Friends { get; set; } = new List<string>();
        public List<string> Players { get; set; } = new List<string>();
    }
}
