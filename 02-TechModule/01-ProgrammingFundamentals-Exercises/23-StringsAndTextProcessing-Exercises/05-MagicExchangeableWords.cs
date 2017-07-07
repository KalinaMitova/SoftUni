using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            string str1 = strings[0];
            string str2 = strings[1];

            bool isExchangeable = IsExchangeable(str1, str2);

            if (isExchangeable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        private static bool IsExchangeable(string str1, string str2)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            int length = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < length; i++)
            {
                char firstStringChar = str1[i];
                char secondStringChar = str2[i];

                if (!dict.ContainsKey(firstStringChar))
                {
                    if (dict.ContainsValue(secondStringChar))
                    {
                        return false;
                    }

                    dict[firstStringChar] = secondStringChar;
                }
                else
                {
                    if (dict[firstStringChar] != secondStringChar)
                    {
                        return false;
                    }
                }
            }

            if (str1.Length > str2.Length)
            {
                for (int i = length - 1; i < str1.Length; i++)
                {
                    if (!dict.ContainsKey(str1[i]))
                    {
                        return false;
                    }
                }
            }
            else if (str1.Length < str2.Length)
            {
                for (int i = length - 1; i < str2.Length; i++)
                {
                    if (!dict.ContainsValue(str2[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
