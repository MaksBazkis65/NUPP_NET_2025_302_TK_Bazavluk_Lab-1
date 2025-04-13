using System;

namespace Fitness.Common
{
    public abstract class Person : Identifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person() { }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} років";
        }
    }
}
