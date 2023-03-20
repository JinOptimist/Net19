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

        public Permission Permission { get; set; } = Permission.WriteNews | Permission.ReadNews;

        public DateTime Birthday { get; set; }

        public bool IsAdult
        {
            get
            {
                return Age >= 18;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var sb = new StringBuilder();

            sb.Append("1");
            sb.Append("2");
            sb.Append("3");

            sb.ToString();

            return base.Equals(obj);
        }
    }
}
