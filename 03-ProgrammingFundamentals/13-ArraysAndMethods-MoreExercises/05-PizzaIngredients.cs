using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();
            int ingredientLength = int.Parse(Console.ReadLine());

            string[] usedIngredients = new string[10];
            int ingredientsLength = ingredients.Length;
            int counter = 0;

            for (int i = 0; i < ingredientsLength; i++)
            {
                if (ingredients[i].Length == ingredientLength)
                {
                    usedIngredients[counter] = ingredients[i];
                    Console.WriteLine($"Adding {ingredients[i]}.");

                    counter++;
                    if (counter == 10)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"Made pizza with total of {counter} ingredients.");
            Console.WriteLine($"The ingredients are: {String.Join(", ", usedIngredients, 0, counter)}.");
        }
    }
}
