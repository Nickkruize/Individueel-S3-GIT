using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly IGDBContext _context;

        public ReviewRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }
    }
}