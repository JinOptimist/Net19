using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IGameRepository : IBaseRepository<IGameDbModel>
    {
        IGameDbModel GetGameByName(string name);

        void RemoveByName(string name);
    }
}
