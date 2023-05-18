using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models
{
    public class GeneralReviewViewModel
    {
        public PagginatorViewModel<ReviewViewModel> PagginatorViewModel { get; set; } 
        public string TextError { get; set; }

        [Required (ErrorMessage = "Текст отзыва не может быть пустым")]
        public string NewReview { get; set; }
    }
}
