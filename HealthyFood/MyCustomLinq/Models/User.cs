using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomLinq.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Height { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now - Birthday).Days / 365;
            }
        }

        public DateTime Birthday { get; set; }

        public bool IsAdult
        {
            get
            {
                return Age >= 18;
            }
        }
    }
}
