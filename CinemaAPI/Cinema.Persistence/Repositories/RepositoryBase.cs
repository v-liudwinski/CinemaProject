using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cinema.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext _repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public void Create(T entity)
    {
        _repositoryContext.Set<T>().Add(entity);
    }
    public void Delete(T entity)
    { 
        _repositoryContext.Set<T>().Remove(entity);    
    }

    public IQueryable<T> FindAll()
    {
        return _repositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return trackChanges? _repositoryContext.Set<T>().Where(expression)
        : _repositoryContext.Set<T>().Where(expression).AsNoTracking();
    }
}
