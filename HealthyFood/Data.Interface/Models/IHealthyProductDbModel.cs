
namespace Data.Interface.Models
{
    public interface IHealthyProductDbModel : IDbModel
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Caloric { get; }
    }
}
