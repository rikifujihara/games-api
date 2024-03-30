using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class ReviewMapping
{

    public static Review ToEntity(this CreateReviewDto review)
    {
        return new Review()
        {
            GameId = review.GameId,
            Stars = review.Stars,
            Description = review.Description
        };
    }

    public static Review ToEntity(this UpdateReviewDto review, int id)
    {
        return new Review()
        {
            Id = id,
            GameId = review.GameId,
            Stars = review.Stars,
            Description = review.Description
        };
    }
    public static ReviewDetailsDto ToDto(this Review review)
    {
        return new ReviewDetailsDto(review.Id, review.GameId, review.Stars, review.Description);
    }
}