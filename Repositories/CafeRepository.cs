using CoffeeNoteBe.Data;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNoteBe.Repositories;

public class CafeRepository : ICafeRepository
{

    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Cafe> _cafes;
    private readonly DbSet<CafeReviewSummary> _cafeReviewSummary;

    public CafeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _cafes = appDbContext.Cafes;
        _cafeReviewSummary = appDbContext.CafeReviewSummary;
    }

    public async Task<int> Add(Cafe cafe)
    {
        _cafes.Add(cafe);

        // Creating cafe should create overall entry in cafe review summary table
        var overAllCafeSummary = new CafeReviewSummary
        {
            Cafe = cafe,
            Category = "Overall",
            TotalRatings = 0,
            TotalReviews = 0
        };

        _cafeReviewSummary.Add(overAllCafeSummary);
        return await _appDbContext.SaveChangesAsync();

    }

    public async Task<Cafe?> GetCafeById(int cafeId)
    {
        var cafe = await _cafes.FindAsync(cafeId);
        return cafe;
    }

}