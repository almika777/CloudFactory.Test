using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BL
{
    public class ReadFileService : IReadFileService
    {

        private static string _dirrectoryToFile = Environment.CurrentDirectory;
        private const string _notExists = "File not exists";

        private Dictionary<string, Task<string>> _readTasks = new Dictionary<string, Task<string>>();

        public async Task<string> ReadFileContentAsync(string filename)
        {
            var fileContent = await ReadFile(filename);
            return string.IsNullOrEmpty(fileContent)
                ? _notExists
                : filename;
        }

        private Task<string> ReadFile(string filename)
        {
            var fileIsReaded = _readTasks.TryGetValue(filename, out Task<string> readTask);

            if (fileIsReaded) return readTask;

            readTask = AddReadFileTask(filename);
            return readTask;
        }

        private Task<string> AddReadFileTask(string filename)
        {
            var readTask = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                _readTasks.Remove(filename);
                if (CheckFileIfExists(filename)) return File.ReadAllText(GetFilePath(filename));
                return _notExists;
            });

            _readTasks.TryAdd(filename, readTask);
            return readTask;
        }

        private static bool CheckFileIfExists(string filename)
            => File.Exists(GetFilePath(filename));

        private static string GetFilePath(string filename)
            => Path.Combine(_dirrectoryToFile, filename);
    }
}
