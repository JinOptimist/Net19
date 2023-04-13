namespace Data.Interface.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }
        public virtual List<Game> Games { get; set; }
        public virtual QuizPlayer QuizPlayer { get; set; }
    }
}
