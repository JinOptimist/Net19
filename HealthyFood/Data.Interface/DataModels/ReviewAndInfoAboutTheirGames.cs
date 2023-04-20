

namespace Data.Sql.DataModels
{
    public class ReviewAndInfoAboutTheirGames
    {
        public string TextReview { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public List<string> GamesName { get; set; }
    }
}
