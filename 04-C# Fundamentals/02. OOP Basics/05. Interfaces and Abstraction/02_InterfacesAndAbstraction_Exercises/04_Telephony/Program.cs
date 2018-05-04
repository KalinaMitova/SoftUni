using System;

namespace _04_Telephony
{
    public class Program
    {
        public static void Main()
        {
            Smartphone phone = new Smartphone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(phone.Call(phoneNumber));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(phone.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
