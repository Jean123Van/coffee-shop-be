using CoffeeNoteBe.DTO.Review;

namespace CoffeeNoteBe.Services;

public class ReviewService
{
    public async Task<GetAllTotalRatings> GetReviewSummaryByCafe(int cafeId)
    {
        var result = new GetAllTotalRatings(
            25,
            4.5,
            [
                    new("Food", 5),
                    new("Service", 4),
                    new("Ambiance", 4)
            ]
        );

        return result;
    }
}