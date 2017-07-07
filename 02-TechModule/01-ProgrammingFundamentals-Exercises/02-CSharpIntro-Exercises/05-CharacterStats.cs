using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int health = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|',health)}{new string('.', maxHealth - health)}|");
            Console.WriteLine($"Energy: |{new string('|', energy)}{new string('.', maxEnergy - energy)}|");
        }
    }
}
