using Tunify.Model;

namespace Tunify.Repositories.Interfaces
{
    public interface IArtist
    {
        Task<Artists> CreateArtist(Artists Artist);
        Task<List<Artists>> GetAllArtists();
        Task<Artists> GetArtistById(int ArtistID);

        Task<Artists> UpdateArtist(int id, Artists Artist);
        Task DeleteArtist(int id);
    }
}
