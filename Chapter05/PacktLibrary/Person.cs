using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
        
    }
}
