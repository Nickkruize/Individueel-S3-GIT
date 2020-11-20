using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InternetGameDatabase.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly IGDBContext _context;

        public ReviewRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }

        public Review GetByIdWithUserAndGame(int id)
        {
            return _context.Reviews
                    .Include(r => r.User)
                    .Include(g => g.Game)
                    .FirstOrDefault(r => r.Id == id);
        }
    }
}