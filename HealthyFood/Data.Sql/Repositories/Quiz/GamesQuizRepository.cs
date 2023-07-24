
using Data.Interface.DataModels;
using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;

using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories.Quiz
{
    public class GamesQuizRepository : BaseRepository<GamesQuiz>, IGamesQuizRepository
    {
        public GamesQuizRepository(WebContext webContext) : base(webContext)
        {
        }

        public List<PlayingQuiz> GetDbQuiz()
        {

            var thisQuiz = _dbSet
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .First();

            var newList = new List<PlayingQuiz>();

            for (int i = 1; i < thisQuiz.Questions.Count; i++)
            {
                var dataModel = new PlayingQuiz
                {
                    QuestionsText = thisQuiz.Questions[i].QuestionText,
                    Answers = thisQuiz.Questions[i].Answers.Select(x=>x.OneAnswer).ToList()
                };
                newList.Add(dataModel);
            }
            return newList;
            //var allQuestionsText = thisQuiz.Questions.Select(x => x.QuestionText).ToList();
            //var allAnswer = thisQuiz.Questions.Select(x => x.Answers).ToList();

            //var newList = new List<PlayingQuiz>();


            //var selectedPeople = thisQuiz.Questions.SelectMany(u => u.QuestionText,
            //                  (u, l) => new { allQuestionsText = u, Answer = l })

            //                .Select(u => u.allQuestionsText);

            //return thisQuiz;
            //foreach (var oneQuestion in allQuestionsText)
            //{
            //    var dataModel = new PlayingQuiz
            //    {
            //        QuestionsText = oneQuestion,
            //        Answers = thisQuiz.Questions.SelectMany

            //    };
            //    newList.Add(dataModel);
            //}

            //var quizModel = new QuizModel
            //{
            //    Questions = thisQuiz.Questions.Select(q => q.QuestionText).ToList(),
            //    Answers = thisQuiz.Questions.SelectMany(q => q.Answers).Select(a => new AnswerModel { AnswerText = a.AnswerText, IsCorrect = a.IsCorrect }).ToList()
            //};
            //return newList;
            //return new PlayingQuiz
            //{
            //    QuestionsText = thisQuiz.Questions.Select(x => x.QuestionText).ToList()
            //};
        }
    }
}
