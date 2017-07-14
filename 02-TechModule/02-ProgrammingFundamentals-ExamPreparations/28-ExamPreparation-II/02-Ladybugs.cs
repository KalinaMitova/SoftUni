using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];
            
            foreach (int ladybug in ladybugs)
            {
                if (ladybug >= 0 && ladybug < fieldSize)
                {
                    field[ladybug] = 1;
                }
            }
            
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                int ladybugIndex = int.Parse(tokens[0]);
                string direction = tokens[1];
                int flyLength = int.Parse(tokens[2]);

                if (ladybugIndex >= 0 && ladybugIndex < field.Length)
                {
                    if (field[ladybugIndex] == 1)
                    {
                        if (direction == "left")
                        {
                            field[ladybugIndex] = 0;
                            int nextPosition = ladybugIndex - flyLength;
                            while (true)
                            {
                                if (!(nextPosition >= 0 && nextPosition < field.Length))
                                {
                                    break;
                                }

                                if (field[nextPosition] == 0)
                                {
                                    field[nextPosition] = 1;
                                    break;
                                }

                                nextPosition -= flyLength;
                            }
                        }
                        else if (direction == "right")
                        {
                            field[ladybugIndex] = 0;
                            int nextPosition = ladybugIndex + flyLength;
                            while (true)
                            {
                                if (!(nextPosition >= 0 && nextPosition < field.Length))
                                {
                                    break;
                                }

                                if (field[nextPosition] == 0)
                                {
                                    field[nextPosition] = 1;
                                    break;
                                }

                                nextPosition += flyLength;
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
