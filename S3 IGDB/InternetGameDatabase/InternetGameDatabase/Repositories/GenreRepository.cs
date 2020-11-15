using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly IGDBContext _context;

        public GenreRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }
    }
}
