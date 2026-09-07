using CatFactTask.Storage;

namespace CatFactTask.Tests;

public class FileWriterTests
{
    [Fact]
    public async Task AppendToFileAsync_WhenCalled_AddsOneLine()
    {
        var dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var fileName = Path.Combine(dir, "catfacts.txt");
        Directory.CreateDirectory(dir);

        await File.WriteAllLinesAsync(fileName, ["First", "Second"]);
        var numberOfLinesBefore = await File.ReadAllLinesAsync(fileName);
        Assert.Equal(2, numberOfLinesBefore.Length);

        var fileWriter = new FileWriter();
        try
        {
            await fileWriter.AppendToFileAsync(fileName, "testfakefactoneline");
            var numberOfLinesAfter = await File.ReadAllLinesAsync(fileName);
            Assert.Equal(numberOfLinesBefore.Length + 1, numberOfLinesAfter.Length);
        }
        finally
        {
            Directory.Delete(dir, true);
        }
    }
}
