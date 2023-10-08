using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
{
    public GenreRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<Genre?> GetGenreAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, false)
            .FirstOrDefaultAsync();
    }
}
