namespace _04_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[n][];

            int size = 1;
            for (int i = 0; i < n; i++)
            {
                jaggedArray[i] = new long[size];

                for (int j = 0; j < size; j++)
                {
                    if (i - 1 < 0 || j - 1 < 0 || j >= size - 1)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    else
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                    }
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
                size++;
            }
        }
    }
}
