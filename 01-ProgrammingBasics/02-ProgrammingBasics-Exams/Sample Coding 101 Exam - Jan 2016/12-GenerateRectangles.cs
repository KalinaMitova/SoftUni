using System;

namespace _12_GenerateRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            bool rects = false;

            int start = n * -1;

            for (int right = start; right <= n; right++)
            {
                for (int left = start; left < right; left++)
                {
                    for (int bottom = start; bottom <= n; bottom++)
                    {
                        for (int top = start; top < bottom; top++)
                        {
                            if ((right - left) * (bottom - top) >= m)
                            {
                                int area = (right - left) * (bottom - top);
                                Console.WriteLine("({0}, {1}) ({2}, {3}) -> {4}", left, top, right, bottom, area);
                                rects = true;
                            }
                        }
                    }
                }
            }

            if(!rects)
            {
                Console.WriteLine("No");
            }
        }
    }
}
