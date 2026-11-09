using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNoteBe.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{


    [Authorize]
    [HttpGet("ratings/get-all/{cafeId:int}")]
    public async Task<IActionResult> GetAllTotalRatings(int cafeId)
    {
        try
        {
            return Ok("Get all ratings endpoint");
        }
        catch (Exception)
        {
            return StatusCode(500, "Something unexpect went wrong.");
        }
    }

}