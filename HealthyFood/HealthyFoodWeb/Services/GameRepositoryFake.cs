using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services
{
    public class GameRepositoryFake : IGameRepository
    {
        public static List<IGameModel> FakeDbGames = 
            new List<IGameModel>() {
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

        public List<IGameModel> GetAll()
        {
            return FakeDbGames;
        }

        public IGameModel GetGameById(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(IGameModel game)
        {
            var maxExistedId = FakeDbGames.Max(x => x.Id);
            game.Id = maxExistedId + 1;
            FakeDbGames.Add(game);
        }
    }
}
