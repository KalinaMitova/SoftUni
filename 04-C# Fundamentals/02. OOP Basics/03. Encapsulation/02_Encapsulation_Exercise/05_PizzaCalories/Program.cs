using System;

public class Program
{
    public static void Main()
    {        
        try
        {
            string[] pizzaInput = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.None);

            string name = pizzaInput[1];

            Pizza pizza = new Pizza(name);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(" ".ToCharArray(), StringSplitOptions.None);

                var ingredient = tokens[0].ToLower();
                
                if (ingredient == "dough")
                {
                    string flourType = tokens[1];
                    string bakingTechnique = tokens[2];
                    double weight = double.Parse(tokens[3]);

                    Dough dough = new Dough(flourType, bakingTechnique, weight);

                    pizza.Dough = dough;
                }
                else if (ingredient == "topping")
                {
                    string toppingType = tokens[1];
                    double toppingWeight = double.Parse(tokens[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}