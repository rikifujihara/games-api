using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class ReviewsEndpoints
{
    const string GetReviewEndpointName = "ReviewGame";
    public static RouteGroupBuilder MapReviewsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("reviews");

        group.MapGet("/{gameId}", async (int gameId, GameStoreContext dbContext) =>
            await dbContext.Reviews
                           .Where(review => review.GameId == gameId)
                           .Select(review => review.ToDto())
                           .AsNoTracking()
                           .ToListAsync()
        );

        group.MapPost("/", async (CreateReviewDto newReview, GameStoreContext dbContext) =>
            {
                Review review = newReview.ToEntity();

                dbContext.Reviews.Add(review);
                await dbContext.SaveChangesAsync();

                return Results.Created();
            }
        );

        return group;
    }
}
