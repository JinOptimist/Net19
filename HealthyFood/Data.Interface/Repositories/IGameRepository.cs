using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IGameRepository
    {
        IGameModel GetGameByName(string name);

        List<IGameModel> GetAll();

        void SaveGame(IGameModel game);

        void RemoveByName(string name);
    }
}
