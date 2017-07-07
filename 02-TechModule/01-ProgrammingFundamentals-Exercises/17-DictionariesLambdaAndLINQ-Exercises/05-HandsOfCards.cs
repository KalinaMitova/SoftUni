using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesCards = new Dictionary<string, List<int>>();

            var line = Console.ReadLine();

            while (line != "JOKER")
            {
                var token = line.Split(':');
                var name = token[0];
                var cards = token[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!namesCards.ContainsKey(name))
                {
                    namesCards[name] = new List<int>();
                }

                var cardsValues = cards.Select(a => CalcCardsValues(a)).ToList();

                namesCards[name].AddRange(cardsValues);

                line = Console.ReadLine();
            }

            foreach (var nameCards in namesCards)
            {
                var name = nameCards.Key;
                var cards = nameCards.Value.Distinct().Sum();
                Console.WriteLine($"{name}: {cards}");
            }
        }
        
        static int CalcCardsValues(string card)
        {
            string power = card.Substring(0, card.Length - 1);
            string type = card.Substring(card.Length - 1);

            var powerValue = new Dictionary<string, int>();

            powerValue["J"] = 11;
            powerValue["Q"] = 12;
            powerValue["K"] = 13;
            powerValue["A"] = 14;

            for (int i = 2; i <= 10; i++)
            {
                powerValue[i.ToString()] = i;
            }

            var typeValue = new Dictionary<string, int>();

            typeValue["S"] = 4;
            typeValue["H"] = 3;
            typeValue["D"] = 2;
            typeValue["C"] = 1;
            
            return powerValue[power] * typeValue[type];
        }
    }
}