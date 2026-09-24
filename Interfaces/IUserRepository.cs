using CoffeeNoteBe.Models;

namespace CoffeeNoteBe.Interfaces;

public interface IUserRepository
{
    Task<int> Add(User user);
    Task<User?> FindOneByEmail(string email);
    Task<User?> FindOneById(int id);
}