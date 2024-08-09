using Tunify.Model;

namespace Tunify.Repositories.Interfaces
{
    public interface ISong
    {
        Task<Songs> CreateSong(Songs Song);
        Task<List<Songs>> GetAllSongs();
        Task<Songs> GetSongById(int SongID);

        Task<Songs> UpdateSong(int id, Songs Song);
        Task DeleteSong(int id);
    }
}
