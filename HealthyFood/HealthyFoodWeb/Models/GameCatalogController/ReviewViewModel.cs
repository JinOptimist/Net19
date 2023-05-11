using HealthyFoodWeb.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models
{
    public class ReviewViewModel
    {
        [Required]
        //[NotProhibited]
        public string TextReview { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string CreatReview { get; set; }
        public List<string> CreatedGame { get; set; }
        public string ErrorMessage { get; set; }
    }
}