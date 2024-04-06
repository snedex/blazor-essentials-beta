using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenreClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync() => 
        await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
}
