using System;

namespace _04_Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double electricity = 0;
            double water = 0;
            double internet = 0;
            double other = 0;

            for (int i = 0; i < months; i++)
            {
                double electricityPrice = double.Parse(Console.ReadLine());
                double otherPrice = 20 + 15 + electricityPrice;
                otherPrice += otherPrice * 0.2;

                electricity += electricityPrice;
                water += 20;
                internet += 15;
                other += otherPrice;
            }

            double bills = (electricity + water + internet + other) / months;
            
            Console.WriteLine("Electricity: {0:F2} lv", electricity);
            Console.WriteLine("Water: {0:F2} lv", water);
            Console.WriteLine("Internet: {0:F2} lv", internet);
            Console.WriteLine("Other: {0:F2} lv", other);
            Console.WriteLine("Average: {0:F2} lv", bills);
        }
    }
}
