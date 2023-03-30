using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class HealthyProductDbModel : BaseDbModel, IHealthyProductDbModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Caloric { get; set; }
    }
}
