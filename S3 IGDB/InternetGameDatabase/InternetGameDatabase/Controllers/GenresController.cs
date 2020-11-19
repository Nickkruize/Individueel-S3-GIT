using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.ContextModel;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // GET: api/Genres
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return _genreRepository.FindAll();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            Genre genre = _genreRepository.GetByIdWithGames(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _genreRepository.Update(genre);

            try
            {
                _genreRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Genre> PostGenre(Genre genre)
        {
            _genreRepository.Create(genre);
            _genreRepository.Save();

            return CreatedAtAction("GetPublisher", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            Genre genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            _genreRepository.Delete(genre);
            _genreRepository.Save();

            return Ok(genre);
        }

        private bool GenreExists(int id)
        {
            if (_genreRepository.GetById(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
