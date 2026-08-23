using CoffeeNoteBe.Data;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models.Authentication;

namespace CoffeeNoteBe.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> Add(User user)
    {
        _appDbContext.Users.Add(user);

        return await _appDbContext.SaveChangesAsync();
    }
}