using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace CodingChallange1_800Application.Services.Utils
{
    public static class Safe
    {
        public static void FileCreate(string filePath, string content)
        {
            CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, content);
        }
        public static void CreateDirectory(string directoryPath)
        {
            if (String.IsNullOrEmpty(directoryPath))
                return;
            Directory.CreateDirectory(directoryPath);
        }
        public static void ResetTestDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
            WaitUntil(() => Directory.Exists(directory), "Failed to create directory " + directory);
        }
        private static void WaitUntil(Func<bool> goal, string failureMessage)
        {
            DateTime startTime = DateTime.Now;
            while (!goal())
            {
                Assert.That(DateTime.Now, Is.LessThanOrEqualTo(startTime.Add(TimeSpan.FromSeconds(3))), 
                    failureMessage);
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
        }
    }
}