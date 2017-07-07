using System;

namespace _11_EnterEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter even number: ");
                string n = Console.ReadLine();

                try
                {
                    int num = int.Parse(n);
                    if(num % 2 == 0)
                    {
                        Console.WriteLine("Even number entered: {0}", num);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number is not even.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            } while (true);
        }
    }
}
