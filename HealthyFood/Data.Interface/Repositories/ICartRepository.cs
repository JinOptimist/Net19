using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface ICartRepository
    {
        ICartModel GetByName(string name);
        List<ICartModel> GetAll();
        void RemoveByName(string name);
    }
}
