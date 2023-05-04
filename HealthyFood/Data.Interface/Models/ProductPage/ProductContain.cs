using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Models.ProductPage
{
    public class ProductContain : BaseModel
    {
        public decimal EnergyValue { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Proteins { get; set; }
    }
}
