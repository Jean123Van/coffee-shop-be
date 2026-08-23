using CoffeeNoteBe.DTO.User;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using CoffeeNoteBe.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CoffeeNoteBe.Services;

public class AuthService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AuthService(IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task<int> Register(RegisterRequest registerRequest)
    {

        var user = new User
        {
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName

        };

        var hashedPassword = _passwordHasher.HashPassword(user, registerRequest.Password);
        user.PasswordHash = hashedPassword;

        return await _userRepository.Add(user);

    }
}