using System.Security.Claims;
using CoffeeNoteBe.DTO.user;
using CoffeeNoteBe.DTO.User;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace CoffeeNoteBe.Services;

public class AuthService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IPasswordHasher<User> passwordHasher, IUserRepository userRepository, IConfiguration configuration)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var (Email, Password) = loginRequest;
        var noAccessMessage = "Invalid email or password.";

        var user = await _userRepository.FindOneByEmail(Email) ?? throw new UnauthorizedAccessException(noAccessMessage);

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException(noAccessMessage);
        }

        var jwtToken = GenerateToken(user);

        return new LoginResponse { Token = jwtToken };
    }
}