using Data.Interface.Models;

namespace Data.Sql.Models;

public class Product : BaseModel
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal Rating { get; set; }
}
