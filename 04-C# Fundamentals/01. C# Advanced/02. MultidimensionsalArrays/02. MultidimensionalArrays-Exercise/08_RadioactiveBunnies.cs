namespace _8_RadioactiveBunnies
{
    using System;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            char[,] lair = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;
            int lastRow = 0;
            int lastCol = 0;

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    lair[i, j] = line[j];
                    if (line[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string directions = Console.ReadLine();

            bool isPlayerAttacked = false;
            bool isPlayerWins = false;

            foreach (var dir in directions)
            {
                lastRow = playerRow;
                lastCol = playerCol;

                lair[playerRow, playerCol] = '.';

                switch (dir)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                }
                if (playerRow < 0 || playerCol < 0 || playerRow == rows || playerCol == cols)
                {
                    isPlayerWins = true;
                }
                else if (lair[playerRow, playerCol] == 'B')
                {
                    isPlayerAttacked = true;
                    lastRow = playerRow;
                    lastCol = playerCol;
                }
                else
                {
                    lair[playerRow, playerCol] = 'P';
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var element = lair[row, col];

                        if (element == 'B')
                        {
                            int up = row - 1;
                            int down = row + 1;
                            int left = col - 1;
                            int right = col + 1;

                            if(up >= 0)
                            {
                                if(lair[up, col] == 'P')
                                {
                                    isPlayerAttacked = true;
                                    lastRow = playerRow;
                                    lastCol = playerCol;
                                }
                                lair[up, col] = 'B';
                            }
                            if(down < rows)
                            {
                                if(lair[down, col] == 'P')
                                {
                                    isPlayerAttacked = true;
                                    lastRow = playerRow;
                                    lastCol = playerCol;
                                }
                                if (lair[down, col] != 'B')
                                {
                                    lair[down, col] = 'b';
                                }
                            }
                            if (left >= 0)
                            {
                                if (lair[row, left] == 'P')
                                {
                                    isPlayerAttacked = true;
                                    lastRow = playerRow;
                                    lastCol = playerCol;
                                }
                                lair[row, left] = 'B';
                            }
                            if (right < cols)
                            {
                                if (lair[row, right] == 'P')
                                {
                                    isPlayerAttacked = true;
                                    lastRow = playerRow;
                                    lastCol = playerCol;
                                }
                                if (lair[row, right] != 'B')
                                {
                                    lair[row, right] = 'b';
                                }
                            }
                        }
                        else if (element == 'b')
                        {
                            lair[row, col] = 'B';
                        }
                    }
                }
                
                if (isPlayerAttacked || isPlayerWins)
                {
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }

            if (!isPlayerWins)
            {
                Console.WriteLine($"dead: {lastRow} {lastCol}");
            }
            else
            {
                Console.WriteLine($"won: {lastRow} {lastCol}");
            }            
        }
    }
}
