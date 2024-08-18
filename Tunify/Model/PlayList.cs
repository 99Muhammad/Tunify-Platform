namespace Tunify.Model
{
    public class PlayList
    {
        public int PlayListID { get; set; }
        public string PlayListName { get; set; }
        public DateTime CreatedDate { get; set; }


        public ICollection<PlayListSong> playListSong { get; set; }=new List<PlayListSong>();
       


    }
}
