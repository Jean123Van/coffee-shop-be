using CoffeeNoteBe.DTO.user;
using CoffeeNoteBe.DTO.User;
using CoffeeNoteBe.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoffeeNoteBe.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        var totalAdded = await _authService.Register(registerRequest);

        if (totalAdded == 1)
        {
            return Ok(new { message = $"User {registerRequest.Email} successfully registered." });
        }
        else
        {
            throw new Exception("User was not saved");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            return Ok(await _authService.Login(loginRequest));
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);

        }
        catch (Exception)
        {
            throw new Exception("Something went wrong logging in. Please try again.");
        }
        ;
    }


}