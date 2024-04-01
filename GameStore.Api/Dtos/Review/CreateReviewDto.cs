using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateReviewDto(
    [Required] int GameId,
    [Range(1, 5)] int Stars,
    string Description
);