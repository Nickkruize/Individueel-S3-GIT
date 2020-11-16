using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly IGDBContext _context;

        public PublisherRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }
    }
}
