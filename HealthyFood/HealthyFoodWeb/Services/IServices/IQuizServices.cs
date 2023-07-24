using HealthyFoodWeb.Models.Quiz;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IQuizServices
    {
        QuizViewModel GetAllQuiz();
        List<StartQuizViewModel> GetQuestion();

    }
}