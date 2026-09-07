using CatFactTask.Client;
using CatFactTask.Service;
using CatFactTask.Storage;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient<ICatFactClient, CatFactClient>(client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja/");
});
services.AddTransient<IFileWriter, FileWriter>();
services.AddTransient<CatFactService>();
await using var serviceProvider = services.BuildServiceProvider();
try
{
    var numberOfFacts = args.Length > 0 && int.TryParse(args[0], out var count) ? count : 5;
    var catFactService = serviceProvider.GetRequiredService<CatFactService>();
    var fileName = Path.Combine("Data", "catfacts.txt");
    Console.WriteLine(
        $"Welcome to CatFacts! Here are {numberOfFacts} facts about cats.\nSaving to {Path.GetFullPath(fileName)}...\n");
    while (numberOfFacts > 0)
    {
        var catFact = await catFactService.GetAndSaveCatFactAsync(fileName);
        Console.WriteLine(catFact.Fact);
        numberOfFacts--;
        if (numberOfFacts != 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}
catch (Exception e)
{
    Console.Error.WriteLine($"Error: {e.Message}");
    return 1;
}

return 0;