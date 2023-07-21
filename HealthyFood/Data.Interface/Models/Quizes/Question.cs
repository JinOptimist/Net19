namespace Data.Interface.Models.Quizes
{
    public class Question : BaseModel
    {
        public int NubmerOfQuestion { get; set; }
        public string QuestionText { get; set; }        
        public virtual GamesQuiz Quiz {get; set;}
        public virtual List<Answer> Answers { get; set; }
    }
}
