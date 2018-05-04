﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashSetPeople = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                hashSetPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashSetPeople.Count);
        }
    }
}
