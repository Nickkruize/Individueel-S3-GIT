using DAL.ContextModel;
using GenericBusinessLogic;
using System.Collections.Generic;

namespace InternetGameDatabase.Repository_Interfaces
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        IEnumerable<Publisher> GetAll();
        Publisher GetByIdWithGames(int id);
    }
}
