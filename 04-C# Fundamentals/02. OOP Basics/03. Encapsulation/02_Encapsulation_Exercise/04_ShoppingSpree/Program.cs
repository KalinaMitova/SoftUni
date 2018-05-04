using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] nameMoney = peopleInput[i].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = nameMoney[0];
                decimal money = decimal.Parse(nameMoney[1]);

                try
                {
                    var person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsInput = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] nameCost = productsInput[i].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = nameCost[0];
                decimal cost = decimal.Parse(nameCost[1]);

                try
                {
                    var product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProduct = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string personName = personProduct[0];
                string productName = personProduct[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                person.BuyProduct(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
