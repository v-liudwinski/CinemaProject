using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Extensions;

public static class RepositoryMovieExtensions
{
    public static IQueryable<Movie> Search(this IQueryable<Movie> movies, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return movies;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return movies.Where(x => x.Title.ToLower().Contains(lowerCaseTerm) 
            || x.OriginalTitle.ToLower().Contains(lowerCaseTerm));
    }
}
