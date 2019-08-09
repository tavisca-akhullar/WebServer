namespace Server
{
    public interface IFileSystem
    {
        string RootPath { get; }
        string TryGetFile(string filePath);
    }
}
