using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Person : IEquatable<Person>
    {
        protected string name;
        protected int age;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Person otherPerson = obj as Person;
            if (otherPerson == null)
                return false;
            else
                return Equals(otherPerson);
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Age == other.Age)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}
