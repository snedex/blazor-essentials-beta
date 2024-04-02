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
            Genre = "Survivorslike",
            Price = 9.99M,
            ReleaseDate = new DateOnly(2023, 02, 01)
        },
    ];

    //Collection expression, fancy!
    public GameSummary[] GetGames => [.. games];
}
