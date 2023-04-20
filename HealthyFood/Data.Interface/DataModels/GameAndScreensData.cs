using Data.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.DataModels
{
    public class GameAndScreensData
    {
        public string GameName { get; set; }
        public string GameCoverUrl { get; set; }
        public List<ScreenAndAuthorNameData> ScreenAndUser { get; set;}
    }
}
