namespace _04_MaximalSum
{
    using System;

    public class MaximumSum
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            long maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                    if (row > 1 && col > 1)
                    {
                        long currentSum = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                currentSum += matrix[row - i, col - j];
                            }
                        }
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            bestRow = row - 2;
                            bestCol = col - 2;
                        }
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);
            if(rows > 2 && cols > 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(matrix[bestRow + i, bestCol + j] + " ");
                    }
                    Console.WriteLine();
                }
            }                    
        }
    }
}
