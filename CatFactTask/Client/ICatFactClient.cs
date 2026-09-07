using CatFactTask.Dto;

namespace CatFactTask.Client;

public interface ICatFactClient
{
    Task<CatFactDto> GetCatFactAsync();
}