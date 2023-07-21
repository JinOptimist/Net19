namespace Data.Interface.Models.Quizes
{
    public class Answer : BaseModel
    {
        public string OneAnswer { get; set; }
        public int NumberAnswer { get; set; }
        public bool IsItTrueAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}
