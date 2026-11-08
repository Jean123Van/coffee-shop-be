using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoffeeNoteBe.DTO.Cafe;
using CoffeeNoteBe.Services;

namespace CoffeeNoteBe.Controllers;

[ApiController]
[Route("api/cafe")]
public class CafeController : ControllerBase
{
    private readonly CafeService _cafeService;

    public CafeController(CafeService cafeService)
    {
        _cafeService = cafeService;
    }

    [Authorize]
    [HttpPost("add-new")]
    public async Task<IActionResult> AddNewCafe([FromForm] AddNewCafeRequest addNewCafeRequest)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!int.TryParse(userId, out var id))
        {
            return Unauthorized("Invalid user ID");
        }

        try
        {
            addNewCafeRequest.UserCreatorId = id;
            var result = await _cafeService.AddNewCafe(addNewCafeRequest);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500, "Something unexpected went wrong.");
        }
    }

    [Authorize]
    [HttpGet("{cafeId:int}")]
    public async Task<IActionResult> GetCafeById(int cafeId)
    {
        try
        {
            return Ok(cafeId);
        }
        catch (Exception)
        {
            return StatusCode(500, "Something unexpected went wrong.");
        }
    }
}