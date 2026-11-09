namespace CoffeeNoteBe.DTO.Review;


public record AverageRatingByCategory(
    string Title,
    double Rating
);

public record GetAllTotalRatings(
    int TotalReviews,
    double AverageRating,
    List<AverageRatingByCategory> Ratings
);