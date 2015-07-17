namespace CodingChallange1_800Application.Services.Interfaces
{
    public interface IFileSystem
    {
        string Read(string filePath);
        void Create(string filePath, string content);
    }
}