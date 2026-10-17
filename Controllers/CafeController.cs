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
    public async Task<IActionResult> AddNewCafe([FromBody] AddNewCafeRequest addNewCafeRequest)
    {
        try
        {
            await _cafeService.AddNewCafe(addNewCafeRequest);
            return Ok("Cafe successfully created");

        }
        catch (Exception)
        {
            return StatusCode(500, "Something unexpected went wrong.");
        }
        ;
    }

}