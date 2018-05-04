using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Playlist playlist = new Playlist(n);

        for (int i = 0; i < n; i++)
        {
            string[] songArgs = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.None);

            string artist = songArgs[0];
            string songName = songArgs[1];
            string songLength = songArgs[2];

            try
            {
                Song song = new Song(artist, songName, songLength);

                playlist.AddSong(song);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(playlist);
    }
}