using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_OnlineRadioDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] songArgs = input.Split(';');

                try
                {
                    string artistName = songArgs[0];
                    string songName = songArgs[1];
                    string[] songLength = songArgs[2].Split(':');
                    
                    int minutes;
                    int seconds;
                    
                    if (songLength.Length != 2 || !int.TryParse((songLength[0]), out minutes) || !int.TryParse((songLength[1]), out seconds))
                    {
                        throw new ArgumentException("Invalid song length.");
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);

                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int songsTotalLengthInSeconds = songs.Sum(s => s.SongLengthInSeconds);
            TimeSpan songsTotalLength = new TimeSpan(0, 0, songsTotalLengthInSeconds);

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {songsTotalLength.Hours}h {songsTotalLength.Minutes}m {songsTotalLength.Seconds}s");
        }
    }
}
