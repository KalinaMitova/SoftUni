using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string bojomonPattern = @"[A-Za-z]+-[A-Za-z]+";
            string didimonPattern = @"[^A-Za-z\-]+";

            string input = Console.ReadLine();

            while (true)
            {
                Match didimonMatch = Regex.Match(input, didimonPattern);
                if (didimonMatch.Success)
                {
                    int index = didimonMatch.Groups[0].Index;
                    int length = didimonMatch.Groups[0].Value.Length;
                    input = input.Remove(0, index + length);
                    Console.WriteLine(didimonMatch.Groups[0].Value);
                }
                else
                {
                    break;
                }

                Match bojomonMatch = Regex.Match(input, bojomonPattern);
                if (bojomonMatch.Success)
                {
                    int index = bojomonMatch.Groups[0].Index;
                    int length = bojomonMatch.Groups[0].Value.Length;
                    input = input.Remove(0, index + length);
                    Console.WriteLine(bojomonMatch.Groups[0].Value);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
