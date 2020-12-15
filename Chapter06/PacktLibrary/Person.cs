using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        //fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        //methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p1.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }
        //Delegates
        public event EventHandler Shout;
        public int AngerLevel;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
                else
                {
                    Console.WriteLine("Null");
                }
            }
        }
        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
