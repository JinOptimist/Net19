
namespace Data.Interface.Models
{
    public interface ISimilarGamesDbModel : IDbModel
    {
        public string SimilarGames { get; set; }
        public string Url { get; set; }
        public string LinkForPicture { get; set; }
    }
}
