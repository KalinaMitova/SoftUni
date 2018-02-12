namespace _01._MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char firstLastLetter = (char)(row + 'a');
                    char middleChar = (char)((row + col) + 'a');
                    matrix[row, col] = $"{firstLastLetter}{middleChar}{firstLastLetter}";
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }            
        }
    }
}
