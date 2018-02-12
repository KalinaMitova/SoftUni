namespace _02_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            int bestSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i, j] = line[j];

                    if(i > 0 && j > 0)
                    {
                        int currentSum = 0;
                        for (int row = 0; row < 2; row++)
                        {
                            for (int col = 0; col < 2; col++)
                            {
                                currentSum += matrix[i - row, j - col];
                            }
                        }

                        if (bestSum < currentSum)
                        {
                            bestSum = currentSum;
                            bestRow = i - 1;
                            bestCol = j - 1;
                        }
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(matrix[bestRow + row, bestCol + col] + " ");                    
                }
                Console.WriteLine();
            }
            Console.WriteLine(bestSum);
        }
    }
}
