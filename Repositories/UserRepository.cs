using CoffeeNoteBe.Data;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNoteBe.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<User> _users;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _users = appDbContext.Users;
    }

    public async Task<int> Add(User user)
    {
        _users.Add(user);

        return await _appDbContext.SaveChangesAsync();
    }

    public async Task<User?> FindOneByEmail(string email)
    {
        return await _users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> FindOneById(int userId)
    {
        return await _users.FirstOrDefaultAsync(user => user.Id == userId);
    }
}