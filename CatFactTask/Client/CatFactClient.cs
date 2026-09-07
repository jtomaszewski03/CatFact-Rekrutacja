using System.Net.Http.Json;
using CatFactTask.Dto;

namespace CatFactTask.Client;

public class CatFactClient(HttpClient httpClient) : ICatFactClient
{
    public async Task<CatFactDto> GetCatFactAsync()
    {
        var response = await httpClient.GetFromJsonAsync<CatFactDto>("fact");
        return response ?? throw new InvalidOperationException("Empty response");
    }
}