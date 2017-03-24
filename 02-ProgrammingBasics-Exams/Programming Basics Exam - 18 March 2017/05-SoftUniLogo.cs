using System;

namespace _05_SoftUniLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int height = 4 * n - 2;
            int width = 12 * n - 5;
            int sharps = 1;
            int dots = 0;
            bool check = true;
            bool check2 = true;

            for (int i = 0; i < height; i++)
            {
                if (i < n * 2)
                {
                    dots = (width - sharps) / 2;
                    Console.WriteLine(new string('.', dots) + new string('#', sharps) + new string('.', dots));
                    sharps += 6;
                }
                else if (i <= height - n)
                {
                    if (check)
                    {
                        dots = 3;
                        check = false;
                    }

                    sharps = width - (dots * 2);
                    Console.WriteLine('|' + new string('.', dots - 1) + new string('#', sharps) + new string('.', dots));
                    dots += 3;
                }
                else
                {
                    if (check2)
                    {
                        dots -= 3;
                        check2 = false;
                    }
                    if (i == height - 1)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write('|');
                    }
                    Console.WriteLine(new string('.', dots - 1) + new string('#', sharps) + new string('.', dots));
                }
            }

        }
    }
}
