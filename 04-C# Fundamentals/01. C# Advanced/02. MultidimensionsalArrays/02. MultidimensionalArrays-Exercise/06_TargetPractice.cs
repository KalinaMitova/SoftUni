namespace TargetPractice
{
    using System;

    class TargetPractice
    {
        static void Main()
        {
            string[] dimenssion = Console.ReadLine().Split();
            int n = int.Parse(dimenssion[0]);
            int m = int.Parse(dimenssion[1]);

            string snakeName = Console.ReadLine();

            string[] shotParameters = Console.ReadLine().Split();
            int impactRow = int.Parse(shotParameters[0]);
            int impactCol = int.Parse(shotParameters[1]);
            int impactArea = int.Parse(shotParameters[2]);

            char[,] matrix = new char[n, m];

            int counter = 0;
            int snakeLength = snakeName.Length;

            int oddOrEven = (n - 1) % 2;

            for (int row = n - 1; row >= 0; row--)
            {
                for (int col = 0; col < m; col++)
                {
                    int direction = col;
                    if (row % 2 == oddOrEven)
                    {
                        direction = m - col - 1;
                    }

                    matrix[row, direction] = snakeName[counter];

                    counter++;
                    if (counter >= snakeLength)
                    {
                        counter = 0;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {

                    double distance = Math.Sqrt(
                        Math.Pow(Math.Abs(impactRow - row), 2) +
                        Math.Pow(Math.Abs(impactCol - col), 2)
                        );

                    if (distance <= impactArea)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            matrix[k, col] = matrix[k - 1, col];
                        }
                        matrix[0, col] = ' ';
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
