namespace _10_TheHeiganDance
{
    using System;

    public class TheHeiganDance
    {
        public static void Main()
        {
            int playerPoints = 18500;
            double heiganPoints = 3000000d;

            int plagueCloudDamage = 3500;
            int eruptionDamage = 6000;

            int dimension = 15;
            int[,] matrix = new int[dimension, dimension];

            int playerRow = dimension / 2;
            int playerCol = dimension / 2;

            matrix[playerRow, playerCol] = 2;

            bool isCloudHit = false;
            string killedBy = string.Empty;

            int[,] directions = new int[,]
            {
                //row, col
                { -1, 0 },
                { 0, 1 },
                { 1, 0 },
                { 0, -1 }
            };

            double playerDamage = double.Parse(Console.ReadLine());

            while (heiganPoints >= 0 && playerPoints >= 0)
            {
                string[] spellArgs = Console.ReadLine().Split();
                string spell = spellArgs[0];
                int row = int.Parse(spellArgs[1]);
                int col = int.Parse(spellArgs[2]);

                if (isCloudHit)
                {
                    playerPoints -= plagueCloudDamage;
                    isCloudHit = false;
                }

                //Player hits Heigan
                heiganPoints -= playerDamage;

                if (heiganPoints < 0 || playerPoints < 0)
                {
                    killedBy = "Plague Cloud";
                    break;
                }

                //Heigan hits Player
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int damagedRow = row + i;
                        int damagedCol = col + j;
                        if (damagedRow >= 0 && damagedRow < dimension &&
                            damagedCol >= 0 && damagedCol < dimension)
                        {
                            matrix[damagedRow, damagedCol]++;
                        }
                    }
                }

                //The player is trying to move
                if (matrix[playerRow, playerCol] > 2)
                {
                    for (int dir = 0; dir < 4; dir++)
                    {
                        int newRow = playerRow + directions[dir, 0];
                        int newCol = playerCol + directions[dir, 1];

                        if (newRow >= 0 && newRow < dimension &&
                            newCol >= 0 && newCol < dimension &&
                            matrix[newRow, newCol] == 0)
                        {
                            matrix[playerRow, playerCol] -= 2;
                            matrix[newRow, newCol] += 2;
                            playerRow = newRow;
                            playerCol = newCol;
                            break;
                        }
                    }
                }

                if (matrix[playerRow, playerCol] > 2)
                {
                    if (spell == "Eruption")
                    {
                        playerPoints -= eruptionDamage;
                    }
                    else if (spell == "Cloud")
                    {
                        playerPoints -= plagueCloudDamage;
                        isCloudHit = true;
                    }
                }

                killedBy = spell;

                //Remove spell
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int damagedRow = row + i;
                        int damagedCol = col + j;

                        if (damagedRow >= 0 && damagedRow < dimension &&
                            damagedCol >= 0 && damagedCol < dimension)
                        {
                            matrix[damagedRow, damagedCol]--;
                        }
                    }
                }
            }

            if (heiganPoints < 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
                Console.WriteLine($"Player: {playerPoints}");
            }
            else if (playerPoints < 0)
            {
                Console.WriteLine($"Heigan: {heiganPoints:F2}");
                Console.WriteLine($"Player: Killed by {killedBy}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }        
    }
}
