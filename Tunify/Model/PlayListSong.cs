namespace Tunify.Model
{
    public class PlayListSong
    {
         public int PlayListSongID { get; set; }

        public int PlayListID { get; set; }
        public int SongID { get; set; }

        public PlayList PlayList { get; set; }
        public Songs Songs { get; set; }


    }
}
