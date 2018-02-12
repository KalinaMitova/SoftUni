namespace _01_DangerousFloor
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int dimension = 8;
            char[,] board = new char[dimension, dimension];

            for (int row = 0; row < dimension; row++)
            {
                string[] cells = Console.ReadLine().Split(',');

                for (int col = 0; col < dimension; col++)
                {
                    board[row, col] = char.Parse(cells[col]);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                char piece = input[0];

                int currentRow = int.Parse(input[1].ToString());
                int currentCol = int.Parse(input[2].ToString());

                int finalRow = int.Parse(input[4].ToString());
                int finalCol = int.Parse(input[5].ToString());
                
                if(board[currentRow, currentCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                bool isValidMove = false;
                switch (piece)
                {
                    case 'K':
                        {
                            if (finalRow >= currentRow - 1 && finalRow <= currentRow + 1 &&
                                finalCol >= currentCol - 1 && finalCol <= currentCol + 1)
                            {
                                isValidMove = true;
                            }
                        }
                        break;
                    case 'R':
                        {
                            if (finalRow == currentRow || finalCol == currentCol)
                            {
                                isValidMove = true;
                            }
                        }
                        break;
                    case 'B':
                        {
                            int rowDif = Math.Abs(currentRow - finalRow);
                            int colDif = Math.Abs(currentCol - finalCol);

                            if (rowDif == colDif)
                            {
                                isValidMove = true;
                            }
                        }
                        break;
                    case 'Q':
                        {
                            int rowDif = Math.Abs(currentRow - finalRow);
                            int colDif = Math.Abs(currentCol - finalCol);

                            if (finalRow == currentRow || finalCol == currentCol ||
                                (rowDif == colDif))
                            {
                                isValidMove = true;
                            }
                        }
                        break;
                    case 'P':
                        {
                            if (finalRow == currentRow - 1 && finalCol == currentCol)
                            {
                                isValidMove = true;
                            }
                        }
                        break;
                }

                if (!isValidMove)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (finalRow < 0 || finalCol < 0 || finalRow >= dimension || finalCol >= dimension)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                if (isValidMove)
                {
                    board[finalRow, finalCol] = piece;
                    board[currentRow, currentCol] = 'x';
                }
            }
        }
    }
}
