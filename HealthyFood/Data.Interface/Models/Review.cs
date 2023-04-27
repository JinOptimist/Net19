
namespace Data.Interface.Models
{
    public class Review : BaseModel
    {
        public string TextReview { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
    }
}
