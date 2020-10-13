using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicDBCore.ContextModel;
using MusicDBCore.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly MusicContext _context;
        public AlbumsController(MusicContext context)
        {
            _context = context;
        }
        // GET: api/<AlbumsController>
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _context.Album;
        }

        // GET api/<AlbumsController>/5
        [HttpGet("{id}")]
        public ActionResult<Album> Get(int id)
        {
            var album = _context.Album.Find(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // POST api/<AlbumsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlbumsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Album album = new Album() { Id = id };
            _context.Album.Attach(album);
            _context.Album.Remove(album);
            _context.SaveChanges();
        }
    }
}

