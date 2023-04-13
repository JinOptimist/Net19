using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class QuizService : IQuizService
    {
        private IQuizRepository _quizRepository;
        private IQuizQuestionsRepository _quizQuestionsRepository;
        public QuizService(IQuizRepository quizRepository, IQuizQuestionsRepository quizQuestionsRepository)
        {
            _quizRepository = quizRepository;
            _quizQuestionsRepository = quizQuestionsRepository;
        }
       
        /// <summary>
        /// Стасистика всех игр
        /// </summary>
        /// <returns></returns>
        public List<Quiz> GetInfo() 
        {
          return _quizRepository.GetInfoAboitQuizGamed().ToList();
        }

        public bool IsAnswerRight(StartQuizViewModel view, int number)
        {
            var rightAnswer = _quizQuestionsRepository.Get(number).RightAnswer;
            if (rightAnswer == view.Value)
            {
                return true;
            }
            else return false;
        }

        //public QuizQuestion Start(int number)
        //{
        //    return _quizQuestionsRepository.Get(number);
        //}
        public void AddGame() //для подсчета вопросо дальше
        {
            var dbPlayerModel = new QuizPlayer()
            {
                NumberQuestion = 1
            };

            _quizQuestionsRepository.Add(dbPlayerModel);
        }
        public QuizPlayer GetGame()
        {
            _quizQuestionsRepository.

        }
    }
}
