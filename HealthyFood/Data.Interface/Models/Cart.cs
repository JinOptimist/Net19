namespace Data.Interface.Models
{
    public class Cart : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public virtual User Customer { get; set; }
    }
}
