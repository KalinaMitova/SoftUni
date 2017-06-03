namespace _17_PrintPartOfASCIITable
{
    using System;

    static class PrintPartOfTable
    {
        static void Main()
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write("{0} ", (char)i);
            }
            Console.WriteLine();
        }
    }
}
