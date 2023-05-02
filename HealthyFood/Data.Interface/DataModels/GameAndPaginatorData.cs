using Data.Interface.Models;

namespace Data.Interface.DataModels
{
    public class GameAndPaginatorData
    {
        public List<Game> Games { get; set; }
        public int TotalCount { get; set; }
    }
}
