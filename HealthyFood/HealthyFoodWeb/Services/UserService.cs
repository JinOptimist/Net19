using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Data.Fake.Models;

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
            var userDbModel = new UserDbModel
            {
                Name = viewModel.Name,
                AvatarUrl = viewModel.AvatarUrl,
            };
            _userRepository.Add(userDbModel);
        }

        public List<IUserDbModel> GetUserModels()
        {
            return _userRepository
                .GetAll()
                .Where(x => x.AvatarUrl != null)
                .ToList();
        }
    }
}
