namespace HealthyFoodWeb.Models
{
    public class CartPagginatorViewModel
    {
        public List<CartViewModel> Product { get; set; }
        public int ActivePageNumber { get; set; }
        public List<int> PageList { get; set; }
    }
}
