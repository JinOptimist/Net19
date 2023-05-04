using Data.Interface.Models;

namespace Data.Interface.Models.ProductPage;

public class Product : BaseModel
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal Rating { get; set; }

    public virtual List<ProductContain> Contains { get; set; }

    public virtual List<ProductCategory> Categories { get; set; }
}
