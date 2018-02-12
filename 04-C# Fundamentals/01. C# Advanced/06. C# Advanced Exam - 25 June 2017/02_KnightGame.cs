namespace _02_KnightGame
{
    using System;
        
    public class KnightGame
    {
        static int[,] moves = new int[,]
        {
                { 2, -1 },
                { 2,  1 },
                {-2, -1 },
                {-2,  1 },
                { 1, -2 },
                { 1,  2 },
                {-1, -2 },
                {-1,  2 }
        };

        private static int count = 0;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            
            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    if(line[j] == 'K')
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            
            var biggestAttacker = FindBiggestAttacker(matrix);

            while (biggestAttacker != null)
            {
                RemoveBiggestAttacker(matrix, biggestAttacker[0], biggestAttacker[1]);
                biggestAttacker = FindBiggestAttacker(matrix);
            }

            Console.WriteLine(count);
        }

        private static void RemoveBiggestAttacker(int[,] matrix, int row, int col)
        {
            for (int dir = 0; dir < 8; dir++)
            {
                int currentRow = row + moves[dir, 0];
                int currentCol = col + moves[dir, 1];

                if (currentRow >= 0 && currentRow < matrix.GetLength(0) &&
                    currentCol >= 0 && currentCol < matrix.GetLength(1))
                {
                    if (matrix[currentRow, currentCol] > 0)
                    {
                        matrix[row, col]--;
                        matrix[currentRow, currentCol]--;
                    }
                }
            }
            count++;
        }
               
        private static int[] FindBiggestAttacker(int[,] matrix)
        {
            int biggestAttackerCunt = 0;
            int[] attacker = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        matrix[row, col] = 0;
                        for (int dir = 0; dir < 8; dir++)
                        {
                            int currentRow = row + moves[dir, 0];
                            int currentCol = col + moves[dir, 1];

                            if (currentRow >= 0 && currentRow < matrix.GetLength(0) &&
                                currentCol >= 0 && currentCol < matrix.GetLength(1))
                            {
                                if (matrix[currentRow, currentCol] > 0)
                                {                                    
                                    matrix[row, col]++;
                                    if(matrix[row, col] > biggestAttackerCunt)
                                    {
                                        biggestAttackerCunt = matrix[row, col];
                                        attacker = new int[] { row, col };
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return attacker;
        }
    }
}