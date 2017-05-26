using System;

namespace _06_DNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int matchSum = int.Parse(Console.ReadLine());
            char startEndSymbol;
            
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        int currentSum = i + j + k;

                        if(currentSum >= matchSum)
                        {
                            startEndSymbol = 'O';
                        }
                        else
                        {
                            startEndSymbol = 'X';
                        }

                        Console.Write($"{startEndSymbol}{GetSymbol(i)}{GetSymbol(j)}{GetSymbol(k)}{startEndSymbol} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static char GetSymbol(int number)
        {
            char symbol = ' ';

            switch (number)
            {
                case 1:
                    symbol = 'A';
                    break;
                case 2:
                    symbol = 'C';
                    break;
                case 3:
                    symbol = 'G';
                    break;
                case 4:
                    symbol = 'T';
                    break;
            }

            return symbol;
        }
    }
}
