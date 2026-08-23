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

    public object Register(RegisterRequest registerRequest)
    {

        var user = new User
        {
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName

        };

        var hashedPassword = _passwordHasher.HashPassword(user, registerRequest.Password);

        user.PasswordHash = hashedPassword;

        return user;

    }
}