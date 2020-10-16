using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MusicDBCore.ContextModel;
using MusicDBCore.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        MusicContext _context;
        public ArtistController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return _context.Artist.ToArray();
        }

        // GET api/<ArtistsController>/5
        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            var artist = _context.Artist.Find(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public ActionResult<Artist> PostArtist(Artist artist)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest("Invalid data.");

            //Artist Artist = Converter.ArtistViewModelToModel(artist);
            //_context.Artist.Add(Artist);

            //_context.SaveChanges();

            return Ok();
        }


        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Artist artist = new Artist() { Id = id };
            _context.Artist.Attach(artist);
            _context.Artist.Remove(artist);
            _context.SaveChanges();
        }
    }
}
