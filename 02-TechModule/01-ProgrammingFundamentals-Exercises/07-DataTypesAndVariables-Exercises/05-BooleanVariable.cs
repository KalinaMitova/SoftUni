namespace _05_BooleanVariable
{
    using System;

    static class BooleanVariable
    {
        static void Main()
        {
            string boolean = Console.ReadLine();

            bool isTrue = Convert.ToBoolean(boolean);

            if(isTrue)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
