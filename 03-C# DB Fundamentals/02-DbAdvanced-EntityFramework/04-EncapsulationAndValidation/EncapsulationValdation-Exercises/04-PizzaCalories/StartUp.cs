namespace _04_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split();
            string flourType = doughInput[1];
            string bakingTechinque = doughInput[2];
            int doughWeight = int.Parse(doughInput[3]);

            Pizza pizza;
            try
            {
                pizza = new Pizza(pizzaName);
                Dough dough = new Dough(flourType, bakingTechinque, doughWeight);
                pizza.Dough = dough;

                string toppingInput;
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    string[] toppingSplit = toppingInput.Split();
                    string toppingType = toppingSplit[1];
                    int toppingWeight = int.Parse(toppingSplit[2]);

                    Topping currentTopping = new Topping(toppingType, toppingWeight);
                    pizza.AddToppig(currentTopping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }                        
        }
    }
}
