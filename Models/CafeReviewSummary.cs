namespace CoffeeNoteBe.Models;

public class CafeReviewSummary
{
    public int Id { get; set; }
    public int CafeId { get; set; }
    public Cafe? Cafe { get; set; }

    public string Category { get; set; } = string.Empty;
    public int TotalReviews { get; set; }
    public int TotalRatings { get; set; }
    public double AverageRating => TotalReviews == 0 ? 0 : (double)TotalRatings / TotalReviews;

}