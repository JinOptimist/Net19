using Data.Interface.DataModels;
using Data.Interface.Models.Quizes;

namespace Data.Interface.Repositories.Quiz
{
    public interface IGamesQuizRepository : IBaseRepository<GamesQuiz>
    {
        PlayingQuiz GetAllQuestion();
    }
}
