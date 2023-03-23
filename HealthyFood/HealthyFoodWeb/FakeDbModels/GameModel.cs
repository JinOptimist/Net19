using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels
{
    public class GameModel : IGameModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
