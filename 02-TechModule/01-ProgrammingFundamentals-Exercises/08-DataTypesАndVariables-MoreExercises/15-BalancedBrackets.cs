namespace _15_BalancedBrackets
{
    using System;

    static class BalancedBrackets
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool bracketToClose = false;
            bool unbalanced = false;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                if (line == "(" && bracketToClose)
                {
                    unbalanced = true;
                }
                if (line == ")" && !bracketToClose)
                {
                    unbalanced = true;
                }
                if (line == "(" && !bracketToClose)
                {
                    bracketToClose = true;
                }
                if (line == ")" && bracketToClose)
                {
                    bracketToClose = false;
                }
            }

            if (unbalanced)
            {
                Console.WriteLine("UNBALANCED");
                return;
            }

            if (bracketToClose)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}
