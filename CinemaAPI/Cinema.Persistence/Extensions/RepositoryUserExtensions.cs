using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Extensions;

public static class RepositoryUserExtensions
{
    public static IQueryable<User> Search(this IQueryable<User> users, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return users;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return users.Where(x => x.FirstName.ToLower().Contains(lowerCaseTerm)
            || x.LastName.ToLower().Contains(lowerCaseTerm));
    }
}
