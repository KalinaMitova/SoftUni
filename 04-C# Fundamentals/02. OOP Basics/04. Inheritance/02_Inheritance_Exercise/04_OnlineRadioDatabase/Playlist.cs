using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private List<Song> playlist;

    public Playlist(int length)
    {
        this.playlist = new List<Song>(length);
    }

    public void AddSong(Song song)
    {
        playlist.Add(song);
        Console.WriteLine("Song added.");
    }

    public int TotalPlaylistTime()
    {
        return this.playlist.Sum(s => s.Minutes * 60 + s.Seconds);
    }

    public override string ToString()
    {
        var totalTime = TotalPlaylistTime();

        int seconds = totalTime % 60;
        int minutes = (totalTime / 60) % 60;
        int hours = totalTime / 60 / 60;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Songs added: {playlist.Count}");
        sb.AppendLine($"Playlist length: {hours}h {minutes}m {seconds}s");

        return sb.ToString();
    }
}