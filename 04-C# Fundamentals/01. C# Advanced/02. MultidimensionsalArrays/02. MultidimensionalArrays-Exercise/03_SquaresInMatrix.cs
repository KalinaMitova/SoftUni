namespace _03_SquaresInMatrix
{
    using System;
    
    public class SquaresInMatrix
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            char[,] matrix = new char[rows, cols];

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = char.Parse(line[col]);
                    if(row > 0 && col > 0)
                    {
                        char firstChar = matrix[row, col];
                        char secondChar = matrix[row, col - 1];
                        char thirdChar = matrix[row - 1, col];
                        char lastChar = matrix[row - 1, col - 1];

                        if (firstChar == secondChar && secondChar == thirdChar && thirdChar == lastChar)
                        {
                            counter++;
                        }
                    }                    
                }
            }
            Console.WriteLine(counter);
        }
    }
}
