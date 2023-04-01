using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels
{
    public class BlockModelBAA : IBlockModelBAA
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int Id { get; set; }
    }
}
