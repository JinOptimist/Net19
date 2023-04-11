using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IUserService
    {
        void AddUser(UserViewModel viewModel);
        List<User> GetUserModels();
        User Login(string login, string password);
    }
}