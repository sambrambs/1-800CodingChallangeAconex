using System;
using System.IO;
using CodingChallange1_800Application.Services.Interfaces;

namespace CodingChallange1_800Application.Services
{
    public class FileSystem : IFileSystem
    {
        public string Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            throw new FileNotFoundException("File not found");
        }
        public void Create(string filePath, string content)
        {
            MakeSureParentDirectoryExists(filePath);
            File.WriteAllText(filePath, content);
        }
        private static void MakeSureParentDirectoryExists(string filePath)
        {
            MakeSureDirectoryExists(Path.GetDirectoryName(filePath));
        }
        private static void MakeSureDirectoryExists(string directory)
        {
            if (String.IsNullOrEmpty(directory))
            {
                return;
            }
            if (Directory.Exists(directory))
            {
                return;
            }
            Directory.CreateDirectory(directory);
        }
    }
}