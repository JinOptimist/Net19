namespace HealthyFoodWeb.Models
{
    public class CartViewModel 
    {
        public CartViewModel(PagginatorViewModel<CartItemViewModel> pagginatorViewModel) 
        { 
            PagginatorViewModel = pagginatorViewModel;
        }

        public decimal TotalPrice { get; set; }

        public PagginatorViewModel<CartItemViewModel> PagginatorViewModel { get; set; }
    }
}
