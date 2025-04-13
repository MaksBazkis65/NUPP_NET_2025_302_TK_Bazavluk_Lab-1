using Fitness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fitness.Common
{
    public class Trainer : Person
    {
        public string Specialization { get; set; }

        public Trainer(string name, int age, string specialization)
        {
            Name = name;
            Age = age;
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} років – {Specialization}";
        }
    }
}
