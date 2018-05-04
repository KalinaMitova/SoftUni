using System;
using System.Linq;

namespace P06_TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLightEnum[] trafficLights = Console.ReadLine()
                .Split()
                .Select(Enum.Parse<TrafficLightEnum>)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                ChangeLights(trafficLights);
                Print(trafficLights);
            }
        }

        private static void Print(TrafficLightEnum[] trafficLights)
        {
            Console.WriteLine(string.Join(" ", trafficLights));
        }

        private static void ChangeLights(TrafficLightEnum[] trafficLights)
        {
            for (int i = 0; i < trafficLights.Length; i++)
            {
                int light = (int)trafficLights[i];
                if(light == 2 || light == 1)
                {
                    light <<= 1;
                }
                else
                {
                    light >>= 2;
                }

                trafficLights[i] = (TrafficLightEnum)light;
            }
        }
    }
}
