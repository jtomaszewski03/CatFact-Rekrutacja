namespace CatFactTask.Storage;

public class FileWriter : IFileWriter
{
    public async Task AppendToFileAsync(string fileName, string content)
    {
        var directory = Path.GetDirectoryName(fileName);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }
        await File.AppendAllTextAsync(fileName, content + Environment.NewLine);
    }
}