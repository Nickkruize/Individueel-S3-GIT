using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicDBCore.ContextModel;
using MusicDBCore.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicDBAPI.Controllers
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
        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _context.Song.ToArray();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            var song = _context.Song.Find(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // POST api/<SongController>
        [HttpPost]
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                //Song song = Converter.SongViewModelToModel(vm);
                _context.Song.Add(song);
                _context.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.Created);
                //return CreatedAtAction("Get", new Song { ID = song.ID }, song);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Song song = new Song() { ID = id };
            _context.Song.Attach(song);
            _context.Song.Remove(song);
            _context.SaveChanges();
        }
    }
}

