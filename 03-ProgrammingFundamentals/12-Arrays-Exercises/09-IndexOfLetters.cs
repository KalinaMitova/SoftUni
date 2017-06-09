using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = {
                'a', 'b', 'c', 'd' ,'e',
                'f', 'g', 'h', 'i' ,'j',
                'k', 'l', 'm', 'n' ,'o',
                'p', 'q', 'r', 's' ,'t',
                'u', 'v', 'w', 'x', 'y',
                'z'
            };

            string word = Console.ReadLine().ToLower();

            int wordLength = word.Length;
            int alphabetLength = alphabet.Length;

            for (int i = 0; i < wordLength; i++)
            {
                for (int j = 0; j < alphabetLength; j++)
                {
                    if (word[i] == alphabet[j])
                    {
                        Console.WriteLine($"{word[i]} -> {j}");
                    }
                }
            }
        }
    }
}