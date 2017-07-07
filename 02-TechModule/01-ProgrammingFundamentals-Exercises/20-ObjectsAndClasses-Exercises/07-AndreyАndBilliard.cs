using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07__AndreyAndBilliard
{
    class Program
    {
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> ShopList { get; set; }

            public int Bill
            {
                get
                {
                    return ShopList.Sum(el => el.Value);
                }
            }
        }

        static void Main(string[] args)
        {
            var productsPrices = new Dictionary<string, decimal>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split('-');

                var product = tokens[0];
                var productPrice = decimal.Parse(tokens[1]);

                if (!productsPrices.ContainsKey(product))
                {
                    productsPrices[product] = 0;
                }
                productsPrices[product] = productPrice;
            }

            var customers = new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();
            while (line != "end of clients")
            {
                var tokens = line.Split("-,".ToCharArray());
                var name = tokens[0];
                var product = tokens[1];
                var quantity = int.Parse(tokens[2]);

                if (!customers.ContainsKey(name) && productsPrices.ContainsKey(product))
                {
                    customers[name] = new Dictionary<string, int>();
                }

                if (productsPrices.ContainsKey(product))
                {
                    if (!customers[name].ContainsKey(product))
                    {
                        customers[name][product] = 0;
                    }

                    customers[name][product] += quantity;
                }

                line = Console.ReadLine();
            }

            var listOfCustomers = new List<Customer>();

            foreach (var person in customers)
            {
                var customer = new Customer
                {
                    Name = person.Key,
                    ShopList = person.Value
                };

                listOfCustomers.Add(customer);
            }

            var totalBill = 0m;

            foreach (var customer in listOfCustomers.OrderBy(c => c.Name))
            {
                Console.WriteLine(customer.Name);

                var bill = 0m;

                foreach (var shopList in customer.ShopList)
                {
                    var product = shopList.Key;
                    var qiantity = shopList.Value;

                    bill += qiantity * productsPrices[product];

                    Console.WriteLine($"-- {product} - {qiantity}");
                }

                totalBill += bill;

                Console.WriteLine($"Bill: {bill:F2}");
            }

            Console.WriteLine($"Total bill: {totalBill:F2}");
        }
    }
}
