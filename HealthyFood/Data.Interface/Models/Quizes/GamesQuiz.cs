namespace Data.Interface.Models.Quizes
{
    public class GamesQuiz : BaseModel
    {
        public string NameQuiz { get; set; }    
    
        public virtual List<Question> Questions { get; set; }
    }
}
