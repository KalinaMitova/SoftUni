using System;

namespace _08_TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double s = double.Parse(Console.ReadLine());
            double comission = -1;

            if(town == "sofia")
            {
                if (s >= 0 && s <= 500) comission = 0.05;
                else if (s > 500 && s <= 1000) comission = 0.07;
                else if (s > 1000 && s <= 10000) comission = 0.08;
                else if (s > 10000) comission = 0.12;
            }
            else if (town == "varna")
            {
                if (s >= 0 && s <= 500) comission = 0.045;
                else if (500 < s && s <= 1000) comission = 0.075;
                else if (1000 < s && s <= 10000) comission = 0.10;
                else if (s > 10000) comission = 0.13;
            }
            else if (town == "plovdiv")
            {
                //5.5%	8%	12%	14.5%
                if (s >= 0 && s <= 500) comission = 0.055;
                else if (500 < s && s <= 1000) comission = 0.08;
                else if (1000 < s && s <= 10000) comission = 0.12;
                else if (s > 10000) comission = 0.145;
            }

            if(comission >= 0)
            {
                Console.WriteLine("{0:F2}", comission * s);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
