using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly IGDBContext _context;

        public GameRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }
    }
}