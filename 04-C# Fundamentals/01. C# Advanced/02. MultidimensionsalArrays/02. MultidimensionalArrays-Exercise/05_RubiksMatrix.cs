namespace _05_RubiksMatrix
{
    using System;

    public class RubiksMatrix
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];
            int[,] swapingMatrix = new int[rows, cols];

            int counter = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = counter;
                    swapingMatrix[i, j] = counter++;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                int rowCol = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                int moves = int.Parse(commandArgs[2]);

                switch (direction)
                {
                    case "down":
                        for (int j = 0; j < moves % rows; j++)
                        {
                            int lastElement = swapingMatrix[rows - 1, rowCol];
                            for (int row = rows - 1; row > 0; row--)
                            {
                                swapingMatrix[row, rowCol] = swapingMatrix[row - 1, rowCol];
                            }
                            swapingMatrix[0, rowCol] = lastElement;
                        }
                        break;
                    case "up":
                        for (int j = 0; j < moves % rows; j++)
                        {
                            int firstElement = swapingMatrix[0, rowCol];
                            for (int row = 0; row < rows - 1; row++)
                            {
                                swapingMatrix[row, rowCol] = swapingMatrix[row + 1, rowCol];
                            }
                            swapingMatrix[rows - 1, rowCol] = firstElement;
                        }
                        break;
                    case "right":
                        for (int j = 0; j < moves % cols; j++)
                        {
                            int lastElement = swapingMatrix[rowCol, cols - 1];
                            for (int col = cols - 1; col > 0; col--)
                            {
                                swapingMatrix[rowCol, col] = swapingMatrix[rowCol, col - 1];
                            }
                            swapingMatrix[rowCol, 0] = lastElement;
                        }
                        break;
                    case "left":
                        for (int j = 0; j < moves % cols; j++)
                        {
                            int firstElement = swapingMatrix[rowCol, 0];
                            for (int col = 0; col < cols - 1; col++)
                            {
                                swapingMatrix[rowCol, col] = swapingMatrix[rowCol, col + 1];
                            }
                            swapingMatrix[rowCol, cols - 1] = firstElement;
                        }
                        break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == swapingMatrix[row, col])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int swapedRow = 0;
                        int swapedCol = 0;

                        int length = rows * cols;
                        for (int i = 0; i < length; i++)
                        {
                            swapedRow = i / rows;
                            swapedCol = (i % cols);
                            if (matrix[row, col] == swapingMatrix[swapedRow, swapedCol])
                            {
                                swapingMatrix[swapedRow, swapedCol] = swapingMatrix[row, col];
                                swapingMatrix[row, col] = matrix[row, col];
                                break;
                            }
                        }
                        Console.WriteLine($"Swap ({row}, {col}) with ({swapedRow}, {swapedCol})");
                    }
                }
            }
        }
    }
}
