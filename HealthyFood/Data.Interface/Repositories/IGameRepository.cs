using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IGameRepository
    {
        IGameModel GetGameById(string name);

        List<IGameModel> GetAll();

        void SaveGame(IGameModel game);
    }
}
