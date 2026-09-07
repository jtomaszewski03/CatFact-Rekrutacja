namespace CatFactTask.Storage;

public interface IFileWriter
{
    Task AppendToFileAsync(string fileName, string content);
}