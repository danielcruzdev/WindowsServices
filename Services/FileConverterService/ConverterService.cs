using System.IO;

namespace FileConverterService
{
    class ConverterService
    {
        private FileSystemWatcher _watcher;
        public bool Start()
        {
            _watcher = new FileSystemWatcher(@"C:\temp\", "file.txt");

            _watcher.Created += FileCreated;

            _watcher.IncludeSubdirectories = false;

            _watcher.EnableRaisingEvents = true;

            return true;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            string content = File.ReadAllText(e.FullPath);
            string upperCase = content.ToUpperInvariant();
            var dir = Path.GetDirectoryName(e.FullPath);
            var convertFileName = Path.GetFileName(e.FullPath) + ".converted";
            var convertedPath = Path.Combine(dir, convertFileName);
            File.WriteAllText(convertedPath, upperCase);
        }

        public bool Stop()
        {
            _watcher.Dispose();
            return true;
        }
    }
}
