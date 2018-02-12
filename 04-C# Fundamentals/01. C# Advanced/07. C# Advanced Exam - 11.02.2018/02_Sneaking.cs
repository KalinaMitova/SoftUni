namespace _02_Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());

            char[][] room = new char[dimension][];

            int nikolasRow = 0;
            int nikolasCol = 0;

            int samRow = 0;
            int samCol = 0;

            for (int i = 0; i < dimension; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
                for (int j = 0; j < room[0].Length; j++)
                {
                    if (room[i][j] == 'N')
                    {
                        nikolasRow = i;
                        nikolasCol = j;
                    }
                    else if (room[i][j] == 'S')
                    {
                        samRow = i;
                        samCol = j;
                    }
                }
            }

            char[] instructions = Console.ReadLine().ToCharArray();

            foreach (var instruction in instructions)
            {
                MoveEnemiesAndCheckForSam(room, samRow, samCol);
                SamMoveAndCheckForEnemy(room, instruction, ref samRow, ref samCol, nikolasRow, nikolasCol);
            }
        }

        private static void SamMoveAndCheckForEnemy(char[][] room, char instruction, ref int samRow, ref int samCol, int nikolasRow, int nikolasCol)
        {
            room[samRow][samCol] = '.';

            if (instruction == 'U')
            {
                samRow -= 1;
            }
            else if (instruction == 'D')
            {
                samRow += 1;
            }
            else if (instruction == 'L')
            {
                samCol -= 1;
            }
            else if (instruction == 'R')
            {
                samCol += 1;
            }

            room[samRow][samCol] = 'S';
            
            if (samRow == nikolasRow)
            {
                room[nikolasRow][nikolasCol] = 'X';
                Console.WriteLine("Nikoladze killed!");
                Print(room);
                Environment.Exit(0);
            }
        }

        private static void MoveEnemiesAndCheckForSam(char[][] room, int samRow, int samCol)
        {
            bool isSamKilled = false;
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[0].Length; col++)
                {
                    char element = room[row][col];
                    if (element == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                            if (samRow == row)
                            {
                                isSamKilled = true;
                            }
                        }
                        else
                        {
                            if (samRow == row && samCol < col)
                            {
                                isSamKilled = true;
                            }
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                    }
                    else if (element == 'b')
                    {
                        if (col == room[0].Length - 1)
                        {
                            room[row][col] = 'd';
                            if (samRow == row)
                            {
                                isSamKilled = true;
                            }
                        }
                        else
                        {
                            if (samRow == row && samCol > col)
                            {
                                isSamKilled = true;
                            }
                            room[row][col] = '.';
                            col++;
                            room[row][col] = 'b';
                        }
                    }
                }
            }

            if(isSamKilled)
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                Print(room);
                Environment.Exit(0);
            }
        }

        private static void Print(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[0].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
