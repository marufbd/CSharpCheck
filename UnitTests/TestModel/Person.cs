using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestModel
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return String.Format("Name:{0}, Age:{1}", Name, Age);
        }
    }


    class Bar
    {
        public bool CanEnter(Person person)
        {
            return person.Age >= 18;
        }
    }
}
