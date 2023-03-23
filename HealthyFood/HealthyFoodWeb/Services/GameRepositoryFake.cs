using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services
{
    public class GameRepositoryFake : IGameRepository
    {
        public List<IGameModel> GetAll()
        {
            return new List<IGameModel>() {
                new GameModel{
                    Id = 1,
                    Name = "Half-Life",
                    Price = 10},
                new GameModel
                {
                    Id = 2,
                    Name = "Tetris",
                    Price = 2
                },
                new GameModel
                {
                    Id = 3,
                    Name = "Packman",
                    Price = 1
                },
            };
        }

        public IGameModel GetGameById(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(IGameModel game)
        {
            throw new NotImplementedException();
        }
    }
}
