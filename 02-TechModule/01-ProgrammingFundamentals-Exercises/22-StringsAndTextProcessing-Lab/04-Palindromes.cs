using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var words = text.Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            var palindromes = new List<string>();

            foreach (var word in words)
            {
                var length = word.Length;

                var isPalindrome = true;
                for (int i = 0; i < length / 2; i++)
                {
                    if (word[i] != word[length - i - 1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine(string.Join(", ", palindromes.Distinct().OrderBy(p => p)));
        }
    }
}
