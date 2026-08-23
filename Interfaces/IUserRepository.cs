using CoffeeNoteBe.Models.Authentication;

namespace CoffeeNoteBe.Interfaces;

public interface IUserRepository
{
    Task<int> Add(User user);
}