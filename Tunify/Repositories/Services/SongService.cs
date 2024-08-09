using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class SongService : ISong
    {

        private readonly TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Songs> CreateSong(Songs Song)
        {
            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return Song;
        }

        public async Task DeleteSong(int id)
        {
            var getSong = await GetSongById(id);
            _context.Entry(getSong).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Songs>> GetAllSongs()
        {
            var allSongs = await _context.Songs.ToListAsync();
            return allSongs;
        }

        public async Task<Songs> GetSongById(int SongID)
        {
            var Song = await _context.Songs.FindAsync(SongID);
            return Song;
        }

        public async Task<Songs> UpdateSong(int id, Songs Song)
        {
            var exsitingSong = await _context.Songs.FindAsync(id);
            exsitingSong = Song;
            await _context.SaveChangesAsync();

            return Song;
        }
    }
}
