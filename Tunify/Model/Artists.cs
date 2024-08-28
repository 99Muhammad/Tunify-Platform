namespace Tunify.Model
{
    public class Artists
    {
        public int ArtistsID { get; set; }
        public string ArtistName { get; set; }
        public string Bio { get; set; }

        public ICollection<Songs>? songs {get;set;} = new List<Songs>();

    }

}
