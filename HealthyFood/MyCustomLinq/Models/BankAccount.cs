namespace MyCustomLinq.Models
{
    public class BankAccount
    {
        public User Owner { get; set; }
        public decimal Money { get; set; }
        public bool IsActive { get; set; }
    }
}
