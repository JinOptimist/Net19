using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IQuizService
    {
        List<Quiz> GetInfo();
        //QuizQuestion Start(int number);
        void AddGame();
        QuizPlayer GetGame();

    }
    
}
