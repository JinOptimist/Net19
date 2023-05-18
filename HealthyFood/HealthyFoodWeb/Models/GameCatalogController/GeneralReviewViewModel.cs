namespace HealthyFoodWeb.Models
{
    public class GeneralReviewViewModel
    {
        public List<ReviewViewModel> ReviewViewModels { get; set; } = new List<ReviewViewModel>();
        public string TextError { get; set; }
    }
}
