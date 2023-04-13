

using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IQuizQuestionsRepository
    {
        QuizQuestion Get(int id);
        void Add(QuizPlayer model);
        void Update(int id);
    }
}
