using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IUserRepository
    {
        IUserModel GetByName(string name);
        List<IUserModel> GetAll();
        void RemoveByName(string name);
        void Add(IUserModel model);
    }
}
