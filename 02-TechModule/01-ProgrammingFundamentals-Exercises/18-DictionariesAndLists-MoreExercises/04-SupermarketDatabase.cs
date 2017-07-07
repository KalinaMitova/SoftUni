using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SupermarketDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var productPriceQuantity = new Dictionary<string, Dictionary<double, int>>();

            while (line != "stocked")
            {
                var tokens = line.Split();
                var product = tokens[0];
                var productPrice = double.Parse(tokens[1]);
                var productQuantity = int.Parse(tokens[2]);

                if (!productPriceQuantity.ContainsKey(product))
                {
                    productPriceQuantity[product] = new Dictionary<double, int>();
                }

                if (!productPriceQuantity[product].ContainsKey(productPrice))
                {
                    productPriceQuantity[product][productPrice] = productQuantity;
                }
                
                line = Console.ReadLine();
            }

            var grandTotal = 0.0;

            foreach (var product in productPriceQuantity)
            {
                var lastPrice = product.Value.Last().Key;
                var totalQuantity = product.Value.Values.Sum();
                var totalProductPrice = lastPrice * totalQuantity;
                grandTotal += totalProductPrice;

                Console.WriteLine($"{product.Key}: ${lastPrice:F2} * {totalQuantity} = ${totalProductPrice:F2}");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }
}
