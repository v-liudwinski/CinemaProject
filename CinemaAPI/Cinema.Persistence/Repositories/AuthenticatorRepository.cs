using System.Diagnostics;
using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class AuthenticatorRepository : IAuthenticatorRepository
{
    private readonly RepositoryContext _context;

    public AuthenticatorRepository(RepositoryContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string login, string password)
    {
        var user = await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
        return user;
    }
}