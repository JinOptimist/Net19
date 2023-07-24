
namespace Data.Interface.DataModels
{
    public class PlayingQuiz
    {
        public string QuestionsText { get; set; }
        public List<string> Answers { get; set; }
        public List<bool> IsItTrue { get; set; }
        //public string QuizName { get; set; }
    }
}
