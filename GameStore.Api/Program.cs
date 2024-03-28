using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games =
[
    new(1, "Street Fighter II", "Fighting", 19.19M, new DateOnly(1992, 7, 1)),
    new(2, "Tekken", "Fighting", 59.99M, new DateOnly(2001, 5, 4)),
    new(3, "Call of Duty", "FPS", 16.19M, new DateOnly(2004, 6, 5))
];

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet(
    "games/{id}",
    (int id) =>
    {
        return games.Find(game => game.Id == id);
    }
);

app.Run();
