using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var participantsAwards = new Dictionary<string, List<string>>();

            List<string> participants = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
            List<string> songs = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();

            string line = Console.ReadLine();
            while (line != "dawn")
            {
                var participantSongAward = line.Split(',').Select(p => p.Trim()).ToArray();
                string participant = participantSongAward[0];
                string song = participantSongAward[1];
                string award = participantSongAward[2];

                if (!participantsAwards.ContainsKey(participant) && 
                    participants.Contains(participant) && 
                    songs.Contains(song))
                {
                    participantsAwards[participant] = new List<string>();
                }

                if (participantsAwards.ContainsKey(participant) && 
                    participants.Contains(participant) && 
                    songs.Contains(song) &&
                    !participantsAwards[participant].Contains(award))
                {
                    participantsAwards[participant].Add(award);
                }

                line = Console.ReadLine();
            }
            
            if (participantsAwards.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }
            
            foreach (var participantAward in participantsAwards
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key))
            {
                string participant = participantAward.Key;
                List<string> awards = participantAward.Value.Distinct().ToList();
                int numberOfAwards = awards.Count;

                Console.WriteLine($"{participant}: {numberOfAwards} awards");

                foreach (string award in awards.OrderBy(a => a))
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
    }
}
