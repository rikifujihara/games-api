using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GameStore.Api.Endpoints;

public static class ReviewsEndpoints
{
    const string GetReviewEndpointName = "ReviewGame";
    public static RouteGroupBuilder MapReviewsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
            .WithParameterValidation();

        group.MapGet("/{gameId}/reviews", async (int gameId, GameStoreContext dbContext) =>
            await dbContext.Reviews
                           .Where(review => review.GameId == gameId)
                           .Select(review => review.ToDto())
                           .AsNoTracking()
                           .ToListAsync()
        );

        group.MapPost("/reviews", async (CreateReviewDto newReview, GameStoreContext dbContext) =>
            {
                Review review = newReview.ToEntity();

                dbContext.Reviews.Add(review);
                await dbContext.SaveChangesAsync();

                return Results.Created();
            }
        );

        group.MapPut("reviews/{id}", async (int id, UpdateReviewDto updatedReview, GameStoreContext dbContext) =>
            {
                var existingReview = await dbContext.Reviews.FindAsync(id);

                if (existingReview is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingReview)
                         .CurrentValues
                         .SetValues(updatedReview.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );

        group.MapDelete("reviews/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Reviews
                        .Where(review => review.Id == id)
                        .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
