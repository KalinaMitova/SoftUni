namespace _12_StringMatrixRotation
{
    using System;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            string[] rotation = Console.ReadLine()
                .Split("()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int degrees = int.Parse(rotation[1]);

            int cols = 0;
            int rows = 0;

            string[] lines = new string[1000];

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                lines[rows] = input;
                if(cols < input.Length)
                {
                    cols = input.Length;
                }
                rows++;
            }

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int length = lines[i].Length;
                for (int j = 0; j < cols; j++)
                {
                    if(j < length)
                    {
                        matrix[i, j] = lines[i][j];
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            int rotations = (degrees / 90) % 4;

            char[,] rotatedMatrix;           
            
            if (rotations % 2 == 0)
            {
                rotatedMatrix = new char[rows, cols];
            }
            else
            {
                rotatedMatrix = new char[cols, rows];
            }

            if(rotations == 0)
            {
                rotatedMatrix = matrix;
            }
            else
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (rotations == 1)
                        {
                            rotatedMatrix[col, rows - row - 1] = matrix[row, col];
                        }
                        else if (rotations == 2)
                        {
                            rotatedMatrix[rows - row - 1, cols - col - 1] = matrix[row, col];
                        }
                        else if (rotations == 3)
                        {
                            rotatedMatrix[cols - col - 1, row] = matrix[row, col];
                        }
                    }
                }
            } 

            for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
                {
                    Console.Write(rotatedMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
