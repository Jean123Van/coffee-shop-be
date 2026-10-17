using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoffeeNoteBe.DTO.Cafe;

namespace CoffeeNoteBe.Controllers;

[ApiController]
[Route("api/cafe")]
public class CafeController : ControllerBase
{

    [Authorize]
    [HttpPost("add-new")]
    public async Task<IActionResult> AddNewCafe([FromBody] AddNewCafeRequest addNewCafeRequest)
    {
        return Ok("Success");
    }

}