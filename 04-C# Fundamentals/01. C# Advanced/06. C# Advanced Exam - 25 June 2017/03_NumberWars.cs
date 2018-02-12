namespace _03_NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        public struct Card
        {
            public Card(string card)
            {
                this.Number = int.Parse(card.Substring(0, card.Length - 1));
                this.CharacterNumber = (int)card[card.Length - 1] - 96;
            }

            public int Number { get; set; }
            public int CharacterNumber { get; set; }
        }

        public static void Main()
        {
            Card[] firstPlayerInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => new Card(c))
                .ToArray();

            Card[] secondPlayerInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => new Card(c))
                .ToArray();

            Queue<Card> firstPlayerCards = new Queue<Card>(firstPlayerInput);
            Queue<Card> secondPlayerCards = new Queue<Card>(secondPlayerInput);

            int countTurns = 0;
            while (countTurns < 1000000 && firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                List<Card> field = new List<Card>();
                
                Card firstPlayerCard = firstPlayerCards.Dequeue();
                Card secondPlayerCard = secondPlayerCards.Dequeue();

                field.Add(firstPlayerCard);
                field.Add(secondPlayerCard);

                countTurns++;

                if (firstPlayerCard.Number > secondPlayerCard.Number)
                {
                    AddWinnerCards(firstPlayerCards, field);
                }
                else if (firstPlayerCard.Number < secondPlayerCard.Number)
                {
                    AddWinnerCards(secondPlayerCards, field);
                }
                else
                {
                    string handWinner = string.Empty;

                    do
                    {
                        List<Card> firstPlayerWarCards = new List<Card>(3);
                        List<Card> secondPlayerWarCards = new List<Card>(3);

                        if (firstPlayerCards.Count < 3 && firstPlayerCards.Count != secondPlayerCards.Count)
                        {
                            handWinner = "second";
                            break;
                        }
                        if(secondPlayerCards.Count < 3 && firstPlayerCards.Count != secondPlayerCards.Count)
                        {
                            handWinner = "first";
                            break;
                        }

                        if(firstPlayerWarCards.Count == 0 && secondPlayerCards.Count == 0)
                        {
                            handWinner = string.Empty;
                            break;
                        }

                        int length = Math.Min(3, firstPlayerCards.Count);

                        for (int i = 0; i < length; i++)
                        {
                            firstPlayerWarCards.Add(firstPlayerCards.Dequeue());
                            secondPlayerWarCards.Add(secondPlayerCards.Dequeue());
                        }

                        field.AddRange(firstPlayerWarCards);
                        field.AddRange(secondPlayerWarCards);

                        int firstPlayerSum = firstPlayerWarCards.Sum(c => c.CharacterNumber);
                        int secondPlayerSum = secondPlayerWarCards.Sum(c => c.CharacterNumber);

                        if(firstPlayerSum > secondPlayerSum)
                        {
                            handWinner = "first";
                            break;
                        }
                        else if (firstPlayerSum < secondPlayerSum)
                        {
                            handWinner = "second";
                            break;
                        }

                    } while (true);
                    
                    if(handWinner == "first")
                    {
                        AddWinnerCards(firstPlayerCards, field);
                    }
                    else if(handWinner == "second")
                    {
                        AddWinnerCards(secondPlayerCards, field);
                    }
                    else
                    {
                        Console.WriteLine($"Draw after {countTurns} turns");
                        return;
                    }
                }
            }

            if(firstPlayerCards.Count == 0)
            {
                Console.WriteLine($"Second player wins after {countTurns} turns");
            }
            else
            {
                Console.WriteLine($"First player wins after {countTurns} turns");
            }
        }       
        
        private static void AddWinnerCards(Queue<Card> player, List<Card> cards)
        {
            foreach (var card in cards
                            .OrderByDescending(c => c.Number)
                            .ThenByDescending(c => c.CharacterNumber))
            {
                player.Enqueue(card);
            }
        }
    }
}
