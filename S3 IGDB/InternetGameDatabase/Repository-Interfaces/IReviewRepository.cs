using DAL.ContextModel;
using GenericBusinessLogic;

namespace InternetGameDatabase.Repository_Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Review GetByIdWithUserAndGame(int id);
    }
}
