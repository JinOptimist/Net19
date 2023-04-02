

using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class SimilarGamesDbModel : BaseDbModel, ISimilarGamesDbModel
    {
        public string SimilarGames { get; set; }
     
    }
}
