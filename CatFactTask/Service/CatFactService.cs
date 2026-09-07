using System.Text.Json;
using CatFactTask.Client;
using CatFactTask.Dto;
using CatFactTask.Storage;

namespace CatFactTask.Service;

public class CatFactService(ICatFactClient catFactClient, IFileWriter fileWriter)
{
    public async Task<CatFactDto> GetAndSaveCatFactAsync(string fileName)
    {
        var catFact = await catFactClient.GetCatFactAsync();
        
        await fileWriter.AppendToFileAsync(fileName, JsonSerializer.Serialize(catFact));
        
        return catFact;
    }
}