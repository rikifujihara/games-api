namespace GameStore.Api.Entities;

public class Review
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int Stars { get; set; }

    public required string Description { get; set; }

}
