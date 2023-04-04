﻿

using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class SimilarGamesDbModel : BaseDbModel, ISimilarGamesDbModel
    {
        public string SimilarGames { get; set; }
        public string Url { get; set; }
        public string LinkForPicture { get; set; }
    }
}