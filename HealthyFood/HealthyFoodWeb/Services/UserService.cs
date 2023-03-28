using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<IUserModel> GetUserModels()
        {
            return _userRepository
                .GetAll()
                .Where(x => x.AvatarUrl != null)
                .ToList();
        }
    }
}
