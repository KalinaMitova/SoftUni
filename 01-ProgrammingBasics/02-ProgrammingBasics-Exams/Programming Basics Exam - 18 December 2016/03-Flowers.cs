using System;

namespace _03_Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            // На първия ред е броят на закупените хризантеми – цяло число в интервала[0... 200]
            // На втория ред е броят на закупените рози – цяло число в интервала[0... 200]
            // На третия ред е броят на закупените лалета – цяло число в интервала[0... 200]
            // На четвъртия ред е посочен сезона – [Spring, Summer, Аutumn, Winter]
            // На петия ред е посочено дали денят е празник – [Y – да / N - не]

            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string isHoliday = Console.ReadLine().ToLower();

            decimal chrysanthemumsPrice, rosesPrice, tulipsPrice;

            switch (season)
            {
                case "spring":
                case "summer":
                    chrysanthemumsPrice = 2m;
                    rosesPrice = 4.1m;
                    tulipsPrice = 2.5m;
                    break;
                case "autumn":
                case "winter":
                    chrysanthemumsPrice = 3.75m;
                    rosesPrice = 4.5m;
                    tulipsPrice = 4.15m;
                    break;
                default: 
                    return;
            }

            if (isHoliday == "y")
            {
                chrysanthemumsPrice += chrysanthemumsPrice * 0.15m;
                rosesPrice += rosesPrice * 0.15m;
                tulipsPrice += tulipsPrice * 0.15m;
            }

            decimal bunchOfFlowersPrice = chrysanthemums * chrysanthemumsPrice + roses * rosesPrice + tulips * tulipsPrice;

            if (tulips > 7 && season == "spring")
            {
                bunchOfFlowersPrice -= bunchOfFlowersPrice * 0.05m;
            }

            if (roses >= 10 && season == "winter")
            {
                bunchOfFlowersPrice -= bunchOfFlowersPrice * 0.1m;
            }

            if (chrysanthemums + roses + tulips > 20)
            {
                bunchOfFlowersPrice -= bunchOfFlowersPrice * 0.2m;
            }

            bunchOfFlowersPrice += 2;

            Console.WriteLine("{0:F2}", bunchOfFlowersPrice);
        }
    }
}
