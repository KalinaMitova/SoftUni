using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(@{6,}|#{6,}|\${6,}|\^{6,})";

            var tickets = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftSide = ticket.Substring(0, 10);
                string rightSide = ticket.Substring(10);

                Match leftSideMatch = Regex.Match(leftSide, pattern);
                Match rightSideMatch = Regex.Match(rightSide, pattern);

                if (leftSideMatch.Success && rightSideMatch.Success)
                {
                    var leftSideSymbol = leftSideMatch.Groups[0].Value[0];
                    var leftSideLength = leftSideMatch.Groups[0].Length;
                    var rightSideSymbol = rightSideMatch.Groups[0].Value[0];
                    var rightSideLength = rightSideMatch.Groups[0].Length;
                    
                    var totalLength = Math.Min(leftSideLength, rightSideLength);

                    if (leftSideSymbol == rightSideSymbol)
                    {
                        if (leftSideLength == 10 && rightSideLength == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {totalLength}{leftSideSymbol} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {totalLength}{leftSideSymbol}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
