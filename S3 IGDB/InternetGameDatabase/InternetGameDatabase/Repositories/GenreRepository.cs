using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InternetGameDatabase.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly IGDBContext _context;

        public GenreRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }

        public Genre GetByIdWithGames(int id)
        {
            return _context.Genres
                .Include(p => p.GameGenres)
                .ThenInclude(g => g.Game)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
