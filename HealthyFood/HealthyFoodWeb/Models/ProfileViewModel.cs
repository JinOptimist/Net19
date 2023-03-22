namespace HealthyFoodWeb.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public int Coins { get; set; }

        public int KalkulatedNumberOne { get; set; }
        public int KalkulatedNumberTwo { get; set; }
        public int KalkulatedResult { get; set; }

        
        public string ActualName { get; set; }

        public MathOperationEnum Operator { get; set; }
    }
}
