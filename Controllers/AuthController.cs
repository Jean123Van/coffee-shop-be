using CoffeeNoteBe.Models.Authentication;
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
    public IActionResult Register([FromBody] RegisterRequest registerRequest)
    {

        var result = _authService.Register(registerRequest);

        return Ok(result);


    }
}