using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
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

        public void AddUser(UserViewModel viewModel)
        {
            var User = new User
            {
                Name = viewModel.Name,
                AvatarUrl = viewModel.AvatarUrl,
            };
            _userRepository.Add(User);
        }

        public User GetById(int currentUserId)
        {
            return _userRepository.Get(currentUserId);
        }

        public List<User> GetUserModels()
        {
            return _userRepository
                .GetAll()
                .Where(x => x.AvatarUrl != null)
                .ToList();
        }

        public User Login(string login, string password)
        {
            return _userRepository.GetByNameAndPassword(login, password);
        }
    }
}
