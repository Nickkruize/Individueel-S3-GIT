using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetGameDatabase.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly IGDBContext _context;

        public GameRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }

        public Game GetByIdWithPublisherAndGenres(int id)
        {
            return _context.Games
                .Include(p => p.Publisher)
                .Include(p => p.GameGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            IEnumerable<Game> games = _context.Games.Include(p => p.Publisher).ToList();
            return games;
        }
    }
}