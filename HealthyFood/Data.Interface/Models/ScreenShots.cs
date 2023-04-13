using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Models
{
    public class ScreenShots : BaseModel
    {
        public virtual Game Game { get; set; }  
        public string UrlScreen { get; set; }
        public virtual User User { get; set; }   
    }
}
