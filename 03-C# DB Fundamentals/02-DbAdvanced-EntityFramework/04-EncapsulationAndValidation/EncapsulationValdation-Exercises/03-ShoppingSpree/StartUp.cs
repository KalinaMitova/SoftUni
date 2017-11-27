namespace _03_ShoppingSpree
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
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            
            string[] personsMoneys = Console.ReadLine().Split(';').Where(pm => pm != string.Empty).ToArray();

            foreach (string personMoney in personsMoneys)
            {

                string[] personMoneySplitted = personMoney.Split('=');

                string name = personMoneySplitted[0];
                decimal money = decimal.Parse(personMoneySplitted[1]);
                                
                try
                {
                    Person currentPerson = new Person(name, money);
                    persons.Add(currentPerson);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] productsPrices = Console.ReadLine().Split(';').Where(pp => pp != string.Empty).ToArray();

            foreach (string productPrice in productsPrices)
            {

                string[] productPriceSplitted = productPrice.Split('=');

                string product = productPriceSplitted[0];
                decimal price = decimal.Parse(productPriceSplitted[1]);
                
                try
                {
                    Product currentProduct = new Product(product, price);
                    products.Add(currentProduct);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string cmdArgs;
            while ((cmdArgs = Console.ReadLine()) != "END")
            {
                string[] personProduct = cmdArgs.Split();

                string personName = personProduct[0];
                string productName = personProduct[1];

                Person currentPerson = persons.Find(p => p.Name == personName);
                Product currentProduct = products.Find(p => p.Name == productName);

                try
                {
                    currentPerson.PurchaseItem(currentProduct);
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var person in persons)
            {
                StringBuilder output = new StringBuilder(person.Name + " - ");
                
                if (person.Products.Count != 0)
                {
                    output.Append(string.Join(", ", person.Products.Select(p => p.Name)));
                }
                else
                {
                    output.Append("Nothing bought");
                }
                
                Console.WriteLine(output);
            }
        }        
    }
}
