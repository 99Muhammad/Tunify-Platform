using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _context;

        public ArtistsController(IArtist context)
        {
            _context = context;
        }


        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artists>>> GetArtists()
        {

            return await _context.GetAllArtists();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtists(int id)
        {

            return await _context.GetArtistById(id);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(int id, Artists artists)
        {
            var updateArtist = await _context.UpdateArtist(id, artists);
            return Ok(updateArtist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        {
            var newArtist = await _context.CreateArtist(artists);
            return Ok(newArtist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtists(int id)
        {
            var deletedArtist = _context.DeleteArtist(id);
            return Ok(deletedArtist);
        }


        //api/Songs/GetAllsongsbyanartist/2
        [HttpGet]
        [Route("[action]/{ArtistId}")]
        public async Task<ActionResult<List<Songs>>> GetAllsongsbyanartist(int ArtistId)
        {
            var AssSongs = await _context.GetAllsongsbyanartists(ArtistId);
            if (AssSongs == null) return NotFound();
            return Ok(AssSongs);
        }


        //api/Songs/artists/1/songs/2
    [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<ActionResult<Songs>> AddSongToArtist(int artistId, int songId)
        {
            var AddSongToArtist = await _context.AddSongToArtist(artistId, songId);
            return Ok(AddSongToArtist);

        }
    }
}
