namespace _08_HouseBuilder
{
    using System;

    static class HouseBuilder
    {
        static void Main()
        {
            int firstPrice = int.Parse(Console.ReadLine());
            int secondPrice = int.Parse(Console.ReadLine());

            int sbytePrice = 0;
            int intPrice = 0;

            if (firstPrice <= sbyte.MaxValue)
            {
                sbytePrice = firstPrice;
                intPrice = secondPrice;
            }
            else
            {
                sbytePrice = secondPrice;
                intPrice = firstPrice;
            }

            long totalPrice = (sbytePrice * 4) + ((long)intPrice * 10);

            Console.WriteLine(totalPrice);
        }
    }
}
