


using Data.Interface.Models;
using Data.Sql.Models;

namespace Data.Sql.Models

{
    public class CatalogDbModel : BaseDbModel, ICatalogDbModel
    {
      
       public string NameCategory { get; set; }

    }
}
