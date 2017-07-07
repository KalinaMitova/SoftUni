using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            double result = GetCubePropertiesByPerimeter(side, parameter);

            Console.WriteLine($"{result:F2}");
        }

        static double GetCubePropertiesByPerimeter(double side, string parameter)
        {
            double result = 0;
            switch (parameter.ToLower())
            {
                case "face":
                    result = Math.Sqrt(2 * Math.Pow(side, 2));
                    break;
                case "space":
                    result = Math.Sqrt(3 * Math.Pow(side, 2));
                    break;
                case "volume":
                    result = Math.Pow(side, 3);
                    break;
                case "area":
                    result = 6 * Math.Pow(side, 2);
                    break;
            }
            return Math.Round(result, 2);
        }
    }
}
