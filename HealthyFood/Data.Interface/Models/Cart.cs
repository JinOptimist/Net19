namespace Data.Interface.Models
{
    public class Cart : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual List<User> Customers { get; set; }

    }
}
