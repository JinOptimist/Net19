using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Models
{
    public class WikiTags : BaseModel
    {
        public string Tag { get; set; }
        public virtual List<WikiMcImage> Images { get; set; }
    }
}