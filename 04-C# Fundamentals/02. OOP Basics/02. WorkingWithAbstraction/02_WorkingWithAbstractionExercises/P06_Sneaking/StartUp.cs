using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[][] room = InitializeRoom(n);

            var moves = Console.ReadLine().ToCharArray();

            MakeMoves(room, moves);
        }

        private static char[][] InitializeRoom(int n)
        {
            char[][] room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                room[row] = rowInput;
            }

            return room;
        }

        private static void MakeMoves(char[][] room, char[] moves)
        {
            Position samPosition = GetSamPosition(room);

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies(room);

                Position enemy = GetEnemyPositionInSpecifiedRow(room, samPosition, new Position());

                CheckIfSamIsKilled(room, samPosition, enemy);

                char direction = moves[i];
                MoveSam(room, direction, samPosition);

                enemy = GetEnemyPositionInSpecifiedRow(room, samPosition, enemy);

                CheckIfNikoladzeIsKilled(room, samPosition, enemy);
            }
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    col = MoveEnemy(room, row, col);
                }
            }
        }

        private static int MoveEnemy(char[][] room, int row, int col)
        {
            if (room[row][col] == 'b')
            {
                if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col + 1] = 'b';
                    col++;
                }
                else
                {
                    room[row][col] = 'd';
                }
            }
            else if (room[row][col] == 'd')
            {
                if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col - 1] = 'd';
                }
                else
                {
                    room[row][col] = 'b';
                }
            }

            return col;
        }

        private static void CheckIfNikoladzeIsKilled(char[][] room, Position samPosition, Position enemy)
        {
            if (room[enemy.Row][enemy.Col] == 'N' && samPosition.Row == enemy.Row)
            {
                room[enemy.Row][enemy.Col] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
        }

        private static void CheckIfSamIsKilled(char[][] room, Position samPosition, Position enemy)
        {
            bool isEnemyOnSameRow = enemy.Row == samPosition.Row;

            if (isEnemyOnSameRow)
            {
                char currentElement = room[enemy.Row][enemy.Col];

                bool isLeftEnemySeeingSam = samPosition.Col < enemy.Col && currentElement == 'd';
                bool isRightEnemySeeingSam = enemy.Col < samPosition.Col && currentElement == 'b';

                if (isLeftEnemySeeingSam || isRightEnemySeeingSam)
                {
                    room[samPosition.Row][samPosition.Col] = 'X';
                    Console.WriteLine($"Sam died at {samPosition.Row}, {samPosition.Col}");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
            }
        }

        private static void MoveSam(char[][] room, char direction, Position samPosition)
        {
            room[samPosition.Row][samPosition.Col] = '.';
            switch (direction)
            {
                case 'U':
                    samPosition.Row--;
                    break;
                case 'D':
                    samPosition.Row++;
                    break;
                case 'L':
                    samPosition.Col--;
                    break;
                case 'R':
                    samPosition.Col++;
                    break;
                default:
                    break;
            }
            room[samPosition.Row][samPosition.Col] = 'S';
        }

        private static Position GetEnemyPositionInSpecifiedRow(char[][] room, Position samPosition, Position enemy)
        {
            for (int j = 0; j < room[samPosition.Row].Length; j++)
            {
                if (room[samPosition.Row][j] != '.' && room[samPosition.Row][j] != 'S')
                {
                    return enemy = new Position(samPosition.Row, j);
                }
            }

            return enemy;
        }

        private static Position GetSamPosition(char[][] room)
        {
            Position samPosition;

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition = new Position(row, col);
                        return samPosition;
                    }
                }
            }

            return null;
        }
    }
}
