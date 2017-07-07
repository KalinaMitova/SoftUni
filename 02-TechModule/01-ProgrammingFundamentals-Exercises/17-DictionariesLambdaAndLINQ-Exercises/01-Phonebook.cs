using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split();
            var command = commands[0];

            var phonebook = new Dictionary<string, string>();

            while (command != "END")
            {
                if (command == "A")
                {
                    var name = commands[1];
                    var phone = commands[2];
                    if (phonebook.ContainsKey(name))
                    {
                        phonebook[name] = phone;
                    }
                    else
                    {
                        phonebook.Add(name, phone);
                    }
                }
                else if (command == "S")
                {
                    var name = commands[1];

                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                commands = Console.ReadLine().Split();
                command = commands[0];
            }
        }
    }
}