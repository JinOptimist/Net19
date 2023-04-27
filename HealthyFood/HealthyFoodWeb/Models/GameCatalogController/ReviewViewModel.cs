using HealthyFoodWeb.Models.ValidationAttributes;

namespace HealthyFoodWeb.Models
{
    public class ReviewViewModel
    {
        [NotProhibited]
        public string TextReview { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string CreatReview { get; set; }
        public List<string> CreatedGame { get; set; }
    }
}