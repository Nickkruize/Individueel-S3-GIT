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
using InternetGameDatabase.ViewModel;

namespace InternetGameDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<GameListViewModel> GetGames()
        {
            List<GameListViewModel> result = new List<GameListViewModel>();

            foreach (Game game in _gameRepository.GetAll().ToList())
            {
                result.Add(ModelConverter.GameEntityToGameListViewModel(game));
            }

            return result;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public IActionResult GetGame(int id)
        {
            Game game = _gameRepository.GetByIdWithPublisherAndGenres(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _gameRepository.Update(game);

            try
            {
                _gameRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostGame(Game game)
        {
            _gameRepository.Create(game);
            _gameRepository.Save();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public ActionResult<Game> DeleteGame(int id)
        {
            Game game = _gameRepository.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameRepository.Delete(game);
            _gameRepository.Save();

            return game;
        }

        private bool GameExists(int id)
        {
            if (_gameRepository.GetById(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
