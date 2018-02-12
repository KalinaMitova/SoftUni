namespace _03_GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentRow = Math.Abs(numbers[i] % 3);
                if (rows < currentRow)
                {
                    rows = currentRow;
                }
            }

            rows++;

            int[] rowsLength = new int[rows];
            for (int i = 0; i < numbers.Length; i++)
            {
                rowsLength[Math.Abs(numbers[i] % 3)]++;                
            }

            int[][] matrix = new int[rows][];
            int[] cols = new int[rows];

            for (int i = 0; i < numbers.Length; i++)
            {
                int row = Math.Abs(numbers[i] % 3);
                if(matrix[row] == null)
                {
                    matrix[row] = new int[rowsLength[row]];
                }
                int col = cols[row];
                matrix[row][col] = numbers[i];
                cols[row]++;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
