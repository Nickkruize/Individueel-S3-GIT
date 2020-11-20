using DAL.ContextModel;
using GenericBusinessLogic;
using System.Collections.Generic;

namespace InternetGameDatabase.Repository_Interfaces
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        IEnumerable<Game> GetAll();
        Game GetByIdWithPublisherAndGenres(int id);
    }
}

