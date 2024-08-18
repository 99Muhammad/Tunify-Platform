using Tunify.Model;

namespace Tunify.Repositories.Interfaces
{
    public interface IPlayList 
    {

        Task<PlayList> CreatePlayList(PlayList employee);
        Task<List<PlayList>> GetAllPlayLists();
        Task<PlayList> GetPlayListById(int employeeId);

        Task<PlayList> UpdatePlayList(int id, PlayList employee);

        Task DeletePlayList(int id);

        Task<List<Songs>> GetSongsByPlaylist(int songid);

        Task<PlayListSong> AddPlayListSong(int songid, int playlistid);
    }
}
