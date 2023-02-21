using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicCollectionApi.Data;
using MusicCollectionApi.Models;

namespace MusicCollectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly MusicContext _context;

        public SongController(MusicContext context)
        {
            _context = context;
        }


        
     // Orginal Metoder
                // GET: api/Song
               [HttpGet]
                public async Task<ActionResult<IEnumerable<Song>>> GetSong()
                {
                  if (_context.Song == null)
                  {
                      return NotFound();
                  }
                  
                return await _context.Song.Include(e => e.Album).ToListAsync();
                }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            if (_context.Song == null)
            {
                return NotFound();
            }
            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }
        

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.SongId)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'MusicContext.Song'  is null.");
            }
            _context.Song.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            if (_context.Song == null)
            {
                return NotFound();
            }
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return (_context.Song?.Any(e => e.SongId == id)).GetValueOrDefault();
        }
    }



        /* METOD jag provade 
        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSong()
        {
            var songAndAlbum = _context.Song
            .Include(s => s.Album)
            .Select(s => new
            {
                SongId = s.SongId,
                Name = s.Title,
                Length = s.Length,
                AlbumId = s.AlbumId,
                Album = s.Album.AlbumName
            }).ToList();
            return Ok(songAndAlbum);
        }
*/
}
