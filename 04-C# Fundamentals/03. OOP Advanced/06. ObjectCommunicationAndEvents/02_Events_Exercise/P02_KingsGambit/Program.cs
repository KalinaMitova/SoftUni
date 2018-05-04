using P02_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_KingsGambit
{
    class Program
    {
        static void Main()
        {
            string kingName = Console.ReadLine();

            IKing king = new King(kingName, new List<ISubordinate>());

            string[] royalGuards = Console.ReadLine().Split();

            foreach (var guardName in royalGuards)
            {
                RoyalGuard royalGuard = new RoyalGuard(guardName);
                king.AddSubordinate(royalGuard);
                
            }

            string[] footmans = Console.ReadLine().Split();

            foreach (var footmanName in footmans)
            {
                Footman footman = new Footman(footmanName);
                king.AddSubordinate(footman);
            }

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                string name = tokens[1];

                switch (command)
                {
                    case "Kill":
                        {
                            ISubordinate subordinate = king.Subordinates.First(s => s.Name == name);
                            subordinate.TakeDamage();
                            if(subordinate.HitPoints <= 0)
                            {
                                subordinate.Die();
                            }
                        }
                        break;
                    case "Attack":
                        king.GetAttacked();
                        break;
                }
            }
        }
    }
}
