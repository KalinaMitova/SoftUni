namespace _04_AddVAT
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Func<double, double> calculateVat = p => p *= 1.2;

            double[] prices = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(p => double.Parse(p, CultureInfo.InvariantCulture))
                .Select(calculateVat)
                .ToArray();

            foreach (double price in prices)
            {
                Console.WriteLine("{0:F2}", price);
            }
        }
    }
}
