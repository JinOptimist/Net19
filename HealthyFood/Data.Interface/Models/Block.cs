using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class Block : BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
