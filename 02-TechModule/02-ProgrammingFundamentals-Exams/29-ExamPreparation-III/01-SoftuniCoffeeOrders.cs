using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_SoftuniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal totalPrice = 0m;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());
                
                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                long totalCapsules = daysInMonth * (long)capsulesCount;
                
                decimal currentPrice = totalCapsules * pricePerCapsule;

                totalPrice += currentPrice;

                Console.WriteLine($"The price for the coffee is: ${currentPrice:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
