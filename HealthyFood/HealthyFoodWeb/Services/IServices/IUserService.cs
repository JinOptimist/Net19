using Data.Interface.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IUserService
    {
        List<IUserModel> GetUserModels();
    }
}