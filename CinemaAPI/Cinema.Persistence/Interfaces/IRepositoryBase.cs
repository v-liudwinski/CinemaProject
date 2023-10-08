using System.Linq.Expressions;

namespace Cinema.Persistence.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void Delete(T entity);
}
