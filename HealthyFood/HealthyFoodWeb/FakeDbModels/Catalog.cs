

using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels

{
    public class Catalog : ICatalog
    {
       public int Id { get; set; }
       public string NameCategory { get; set; }

    }
}
