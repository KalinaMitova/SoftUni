namespace _04_VariableInHexFormat
{
    using System;

    static class VariableInHexFormat
    {
        static void Main()
        {
            string hexNum = Console.ReadLine();
            int number = Convert.ToInt32(hexNum, 16);
            Console.WriteLine(number);
        }
    }
}
