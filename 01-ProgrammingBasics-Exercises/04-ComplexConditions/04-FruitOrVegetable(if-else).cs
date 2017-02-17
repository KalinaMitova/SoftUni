using System;

namespace _04_FruitOrVegetable_if_else_
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();

            if(product == "banana" || product == "apple" || product == "kiwi" || 
                product == "cherry" || product == "lemon" || product == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if(product == "tomato" || product == "cucumber" || 
                product == "pepper" || product == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
