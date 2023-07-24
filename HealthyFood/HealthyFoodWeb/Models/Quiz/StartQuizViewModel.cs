namespace HealthyFoodWeb.Models.Quiz
{
    public class StartQuizViewModel
    {
        public string Ques { get; set; }
        public List<string> Answers { get; set; }
        public int Number { get; set; }
        public List<bool> IsItTrueAnswer { get; set; }
        public bool IsRightThisAnswer { get; set; }
        public int CountOfTrueAnswers { get; set; } = 0;
        public int CountAllQuestions { get; set; }
    }
}
