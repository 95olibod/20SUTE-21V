using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01.Domain
{

    public class Calculator{
        public int Add(int x, int y)
        {return x + y;}

    }

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
    }



    public class Playlist
    {
        public Playlist()
        {
            Songs = new List<Song>();
        }
        public List<Song> Songs { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public void Clear()
        {
            Songs.Clear();
        }

        public void AddSong(Song songToAdd)
        {
            if (songToAdd.Artist == "ABBA")
                throw new InvalidOperationException("Hej");

            songToAdd.Title = $"2021 {songToAdd.Title}";
            Songs.Add(songToAdd);

            Songs.Sort(new ArtistTitleComparer());
        }

        public class ArtistTitleComparer : Comparer<Song>
        {
            public override int Compare(Song x, Song y)
            {
                if (x.Artist.CompareTo(y.Artist) != 0) return x.Artist.CompareTo(y.Artist);
                return 0;
            }
        }
    }
}
