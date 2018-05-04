using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if(value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            artistName = value;
        }
    }
    
    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }

            songName = value;
        }
    }
    
    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }

            minutes = value;
        }
    }
    
    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            seconds = value;
        }
    }

    public Song(string artistName, string songName, string songLength)
    {

        if (string.IsNullOrEmpty(artistName) || string.IsNullOrEmpty(songName) || string.IsNullOrEmpty(songLength))
        {
            throw new ArgumentException("Invalid song.");
        }

        this.ArtistName = artistName;
        this.SongName = songName;

        string[] minSec = songLength.Split(":".ToCharArray(), StringSplitOptions.None);

        bool isMinute = int.TryParse(minSec[0], out int minute);
        bool isSecond = int.TryParse(minSec[1], out int second);

        if (minSec.Length != 2 || !isMinute || !isSecond)
        {
            throw new ArgumentException("Invalid song length.");
        }
                        
        this.Minutes = minute;
        this.Seconds = second;
    }
}