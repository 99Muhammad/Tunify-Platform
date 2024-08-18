namespace Tunify.Model
{
    public class Songs
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public TimeSpan Durtion { get; set; }
        public string Genre { get; set; }


        public int ArtistID { get; set; }
        public Artists artists { get; set; }
        public ICollection<PlayListSong> playListSong { get; set; } = new List<PlayListSong>();

    }
}
