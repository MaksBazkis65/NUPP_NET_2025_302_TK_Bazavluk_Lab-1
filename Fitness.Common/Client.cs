using Fitness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fitness.Common
{
    public class Client : Person
    {
        public string Email { get; set; }

        public Client() { }

        public Client(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} років, Email: {Email}";
        }
    }
}
