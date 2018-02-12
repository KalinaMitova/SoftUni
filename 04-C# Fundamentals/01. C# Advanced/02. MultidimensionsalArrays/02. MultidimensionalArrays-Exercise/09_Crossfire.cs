namespace _09_Crossfire
{
    using System;

    public class Crossfire
    {
        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] field = new int[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = (cols * i) + j + 1;
                }
            }

            string fire;
            while ((fire = Console.ReadLine()) != "Nuke it from orbit")
            {
                string[] args = fire.Split();
                long row = long.Parse(args[0]);
                long col = long.Parse(args[1]);
                int radius = int.Parse(args[2]);

                if (row >= 0 && row < rows && col >= 0 && col < cols)
                {
                    field[row, col] = 0;
                }

                for (int i = 1; i <= radius; i++)
                {
                    long up = row - i;
                    long down = row + i;
                    long left = col - i;
                    long right = col + i;

                    if (up >= 0 && up < rows && col >= 0 && col < cols)
                    {
                        field[up, col] = 0;
                    }
                    if (down >= 0 && down < rows && col >= 0 && col < cols)
                    {
                        field[down, col] = 0;
                    }
                    if (left >= 0 && left < cols && row >= 0 && row < rows)
                    {
                        field[row, left] = 0;
                    }
                    if (right >= 0 && right < cols && row >= 0 && row < rows)
                    {
                        field[row, right] = 0;
                    }
                }

                int[,] newField = new int[rows, cols];
                int newFieldRow = 0;
                int newFieldCol = 0;

                for (int i = 0; i < rows; i++)
                {
                    newFieldCol = 0;
                    bool isColEmpty = true;
                    for (int j = 0; j < cols; j++)
                    {
                        if(field[i, j] != 0)
                        {
                            newField[newFieldRow, newFieldCol] = field[i, j];
                            newFieldCol++;
                            isColEmpty = false;
                        }
                    }
                    if (!isColEmpty)
                    {
                        newFieldRow++;
                    }
                }

                field = newField;                
            }
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int element = field[row, col];

                    if (element == 0)
                    {
                        break;
                    }
                    
                    Console.Write(element + " ");                    
                }

                Console.WriteLine();                
            }
        }
    }
}
