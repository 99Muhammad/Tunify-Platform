using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class ArtistService : IArtist
    {
        private readonly TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artists> CreateArtist(Artists Artist)
        {
            _context.Artists.Add(Artist);
            await _context.SaveChangesAsync();

            return Artist;
        }

        public async Task DeleteArtist(int id)
        {
            var getArtist = await GetArtistById(id);
            _context.Entry(getArtist).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Artists>> GetAllArtists()
        {
            var allArtists = await _context.Artists.ToListAsync();
            return allArtists;
        }

        public async Task<Artists> GetArtistById(int ArtistID)
        {
            var Artist = await _context.Artists.FindAsync(ArtistID);
            return Artist;
        }

        public async Task<Artists> UpdateArtist(int id, Artists Artist)
        {
            var exsitingArtist = await _context.Artists.FindAsync(id);
            exsitingArtist = Artist;
            await _context.SaveChangesAsync();

            return Artist;
        }
    }
}
