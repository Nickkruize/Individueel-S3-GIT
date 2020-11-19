using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
using InternetGameDatabase.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetGameDatabase.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly IGDBContext _context;

        public PublisherRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }

        public Publisher GetByIdWithGames(int id)
        {
            return _context.Publishers.Include(p => p.Games).FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.Include(p => p.Games).ToList().AsEnumerable();
        }
    }
}
