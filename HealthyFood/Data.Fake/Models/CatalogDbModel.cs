

using Data.Fake.Models;
using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels

{
    public class CatalogDbModel : BaseDbModel, ICatalogDbModel
    {
      
       public string NameCategory { get; set; }

    }
}
