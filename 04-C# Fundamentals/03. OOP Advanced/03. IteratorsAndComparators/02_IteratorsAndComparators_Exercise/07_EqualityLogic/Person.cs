﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
        
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if(result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;
            if(this.Name == person.Name && this.Age == person.Age)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}