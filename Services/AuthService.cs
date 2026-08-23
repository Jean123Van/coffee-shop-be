using CoffeeNoteBe.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CoffeeNoteBe.Services;

public class AuthService
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(User user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }
}