using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericBusinessLogic
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        T Delete(T entity);
        void Save();
    }
}
