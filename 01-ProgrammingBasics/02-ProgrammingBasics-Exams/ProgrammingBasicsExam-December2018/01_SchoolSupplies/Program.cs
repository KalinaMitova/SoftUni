namespace _01_SchoolSupplies
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double penPackPrice = 5.8;
            double markerPackPrice = 7.2;
            double detergentPrice = 1.2;

            int penPackCount = int.Parse(Console.ReadLine());
            int markerPackCount = int.Parse(Console.ReadLine());
            double detergentLiters = double.Parse(Console.ReadLine());
            int discountInPercents = int.Parse(Console.ReadLine());

            double totalPrice = (penPackPrice * penPackCount) + (markerPackPrice * markerPackCount) + (detergentPrice * detergentLiters);
            
            double priceWithDiscount = totalPrice * ((100 - discountInPercents) / 100.0);

            Console.WriteLine("{0:F3}", priceWithDiscount);
        }
    }
}
