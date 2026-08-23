using CoffeeNoteBe.Models;

namespace CoffeeNoteBe.Interfaces;

public interface IUserRepository
{
    Task<int> Add(User user);
}