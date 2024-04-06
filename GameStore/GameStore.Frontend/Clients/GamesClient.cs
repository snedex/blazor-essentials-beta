using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = [
        new () {
            Id = 1, 
            Name = "Bioshock",
            Genre = "Roleplaying",
            Price = 45.99M,
            ReleaseDate = new DateOnly(2009, 01, 01)
        },
        new () {
            Id = 2, 
            Name = "Baldur's Gate 3",
            Genre = "Combat Roleplaying",
            Price = 79.99M,
            ReleaseDate = new DateOnly(2023, 08, 01)
        },
        new () {
            Id = 3, 
            Name = "Vampire Survivors",
            Genre = "Fighting",
            Price = 9.99M,
            ReleaseDate = new DateOnly(2023, 02, 01)
        },
    ];

    private readonly Genre[] genres = new GenreClient().GetGenres();

    //Collection expression, fancy!
    public GameSummary[] GetGames => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrEmpty(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var GameSummary = new GameSummary()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(GameSummary);
    }

    public GameDetails GetGame(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = genres.Single(genre => string.Equals(
            genre.Name, 
            game.Genre, 
            StringComparison.OrdinalIgnoreCase));

        return new() {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}
