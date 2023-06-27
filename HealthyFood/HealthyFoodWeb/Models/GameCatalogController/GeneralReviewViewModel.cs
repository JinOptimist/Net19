using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models
{
    public class GeneralReviewViewModel
    {
        public List<ReviewViewModel> ReviewViewModels { get; set; } = new List<ReviewViewModel>();
        //public string? TextError { get; set; }

        [Required (ErrorMessage = "Текст отзыва не может быть пустым")]
        public string NewReview { get; set; }
    }
}
