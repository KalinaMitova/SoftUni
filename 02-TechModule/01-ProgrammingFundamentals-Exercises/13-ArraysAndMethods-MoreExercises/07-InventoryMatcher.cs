using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_InventoryMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            string[] quantities = Console.ReadLine().Split();
            string[] prices = Console.ReadLine().Split();

            string productName = Console.ReadLine();

            while (productName != "done")
            {
                if (names.Contains(productName))
                {
                    int index = Array.IndexOf(names, productName);
                    Console.WriteLine($"{names[index]} costs: {prices[index]}; Available quantity: {quantities[index]}");                    
                }
                productName = Console.ReadLine();
            }
        }
    }
}
