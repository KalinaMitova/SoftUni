namespace _07_LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstArray = new int[n][];

            int totalNumberOfCells = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input != string.Empty)
                {
                    int[] line = input
                        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    firstArray[i] = line;
                }
                else
                {
                    firstArray[i] = new int[0];
                }
                totalNumberOfCells += firstArray[i].Length;
            }

            int[][] secondArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if(input != string.Empty)
                {
                    int[] line = input
                        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .Reverse()
                        .ToArray();

                    secondArray[i] = line;
                }     
                else
                {
                    secondArray[i] = new int[0];
                }
                totalNumberOfCells += secondArray[i].Length;
            }
            
            bool isEqual = true;
            int totalLength = firstArray[0].Length + secondArray[0].Length;
            for (int row = 1; row < n; row++)
            {
                int currentLength = firstArray[row].Length + secondArray[row].Length;

                if (totalLength != currentLength)
                {
                    isEqual = false;
                    break;
                }
            }

            if (isEqual)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.Write("[");
                    for (int col = 0; col < firstArray[row].Length; col++)
                    {
                        Console.Write(firstArray[row][col]);
                        if(col != firstArray[row].Length - 1 || col != totalLength - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    for (int col = 0; col < secondArray[row].Length; col++)
                    {
                        Console.Write(secondArray[row][col]);
                        if (col != secondArray[row].Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalNumberOfCells}");
            }            
        }
    }
}
