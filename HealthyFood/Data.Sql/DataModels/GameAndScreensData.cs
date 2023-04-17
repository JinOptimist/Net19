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
        public Game Game { get; set; }
        public List<ScreenAndAuthorNameData> ScreenAndUser { get; set;}
    }
}
