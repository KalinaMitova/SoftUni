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
            string[] productNames = Console.ReadLine().Split();
            long[] quantities = Console.ReadLine().Split().Select(long.Parse).ToArray();
            double[] prices = Console.ReadLine().Split().Select(double.Parse).ToArray();

            string[] productNameAndQuantity = Console.ReadLine().Split();

            while (productNameAndQuantity[0] != "done")
            {
                string productName = productNameAndQuantity[0];
                long productQuantity = long.Parse(productNameAndQuantity[1]);

                if (productNames.Contains(productName))
                {
                    int index = Array.IndexOf(productNames, productName);
                    if (index <= quantities.Length - 1 && productQuantity <= quantities[index])
                    {
                        decimal totalPrice = productQuantity * (decimal)prices[index];
                        Console.WriteLine($"{productName} x {productQuantity} costs {totalPrice:F2}");
                        quantities[index] -= productQuantity;
                    }
                    else
                    {
                        Console.WriteLine($"We do not have enough {productNames[index]}");
                    }
                }

                productNameAndQuantity = Console.ReadLine().Split();
            }
        }
    }
}
