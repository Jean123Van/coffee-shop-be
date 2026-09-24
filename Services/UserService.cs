using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using CoffeeNoteBe.Repositories;

namespace CoffeeNoteBe.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetMeDetails(int userId)
    {

        var user = await _userRepository.FindOneById(userId);

        if (user == null)
        {
            throw new KeyNotFoundException("Invalid user ID");
        }

        return user;
    }
}