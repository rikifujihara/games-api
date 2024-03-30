namespace GameStore.Api.Dtos;

public record class ReviewDetailsDto(
    int Id,
    int GameId,
    int Stars,
    string Description
);
