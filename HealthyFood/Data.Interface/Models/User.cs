namespace Data.Interface.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public virtual List<Cart> Products { get; set; }

    }
}
