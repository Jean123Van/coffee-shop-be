using CoffeeNoteBe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNoteBe.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [Authorize]
    [HttpGet("ratings/get-all/{cafeId:int}")]
    public async Task<IActionResult> GetReviewSummaryByCafe(int cafeId)
    {
        try
        {
            var result = await _reviewService.GetReviewSummaryByCafe(cafeId);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500, "Something unexpect went wrong.");
        }
    }

}